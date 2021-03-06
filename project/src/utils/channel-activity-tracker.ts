import {VoiceConnection} from "@discordjs/voice";
import {VoiceChannel} from "discord.js";
import {Observable, Subject, Subscription, timer} from "rxjs";
import {MAXIMUM_INACTIVITY_THRESHOLD} from "../constants/session-constants";
import {SessionSettings} from "../interfaces/session-settings";
import {InterventionsRecord} from "./InterventionsRecord";
import {SpeakerScore} from "./speaker-score/speaker-score";

export class ChannelActivityTracker {
    public settings: SessionSettings;
    private voiceConnection: VoiceConnection;
    private voiceChannel: VoiceChannel;
    private readonly connectionsRecord: InterventionsRecord;
    private readonly voiceInterventionsRecord: InterventionsRecord;

    private inactivityTimeoutSubject = new Subject<void>();
    private timeoutTimerSubscription: Subscription | null;

    constructor(voiceChannel: VoiceChannel, voiceConnection: VoiceConnection, settings: SessionSettings | null) {
        this.voiceChannel = voiceChannel;
        this.voiceConnection = voiceConnection;
        this.settings = settings;
        this.connectionsRecord = new InterventionsRecord(settings);
        this.voiceInterventionsRecord = new InterventionsRecord(settings);
        this.settings.speakerScorer.setup(this.connectionsRecord, this.voiceInterventionsRecord);
        this.start();
    }

    public getUserRelevantScore(userId: string): SpeakerScore {
        return this.settings.speakerScorer.getSpeakerScore(userId);
    }

    public getInactivityTimeoutObservable(): Observable<void> {
        return this.inactivityTimeoutSubject.asObservable();
    }

    public end(): void {
        this.voiceConnection.receiver.speaking.removeAllListeners();
        this.timeoutTimerSubscription.unsubscribe();
    }

    public setPrivilegedSpeakers(privilegedSpeakers: string[]): void {
        this.voiceInterventionsRecord.setExemptedMembers(privilegedSpeakers);
    }

    public getPrivilegedSpeakers(): Set<string> {
        return this.voiceInterventionsRecord.getExemptedMembers();
    }

    public onUserParticipationStatusChange(userId: string, becomingActive: boolean): void {
        becomingActive ? this.connectionsRecord.onInterventionStart(userId)
            : this.connectionsRecord.onInterventionStop(userId);
    }

    private start(): void {
        this.voiceConnection.receiver.speaking.on("start", ((userId) => {
            this.refreshInactivityTimeoutTimer();
            this.voiceInterventionsRecord.onInterventionStart(userId);
        }));
        this.voiceConnection.receiver.speaking.on("end", ((userId) => {
            this.refreshInactivityTimeoutTimer();
            this.voiceInterventionsRecord.onInterventionStop(userId);
        }));
        this.settings.getScorerChangeObservable().subscribe(() => {
            this.settings.speakerScorer.setup(this.connectionsRecord, this.voiceInterventionsRecord);
        });
        this.registerAllConnectedUsers();
        this.refreshInactivityTimeoutTimer();
    }

    private registerAllConnectedUsers(): void {
        const humanUsersInChannel = Array.from(this.voiceChannel.members).filter(([_, user]) => !user.user.bot);
        humanUsersInChannel.forEach(([userId, _]) => this.connectionsRecord.onInterventionStart(userId));
    }

    private refreshInactivityTimeoutTimer(): void {
        if (this.timeoutTimerSubscription) {
            this.timeoutTimerSubscription.unsubscribe();
        }

        this.timeoutTimerSubscription = timer(MAXIMUM_INACTIVITY_THRESHOLD).subscribe(() => {
            this.inactivityTimeoutSubject.next();
        });
    }
}
