// <auto-generated />
//
// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do one of these:
//
//    using QuickType;
//
//    var sessionCreationRequest = SessionCreationRequest.FromJson(jsonString);
//    var sessionCreationRequestResponse = SessionCreationRequestResponse.FromJson(jsonString);
//    var userProfileInfo = UserProfileInfo.FromJson(jsonString);
//    var socketConnectionInfo = SocketConnectionInfo.FromJson(jsonString);
//    var userSessionEvent = UserSessionEvent.FromJson(jsonString);
//    var scoresUpdateEvent = ScoresUpdateEvent.FromJson(jsonString);
//    var userConnectionStatusEvent = UserConnectionStatusEvent.FromJson(jsonString);
//    var notificationFromSessionEvent = NotificationFromSessionEvent.FromJson(jsonString);
//    var notificationToSessionEvent = NotificationToSessionEvent.FromJson(jsonString);
//    var userScore = UserScore.FromJson(jsonString);
//    var sessionStateInfo = SessionStateInfo.FromJson(jsonString);
//    var dbUserProfileInfo = DbUserProfileInfo.FromJson(jsonString);
//    var omiliaError = OmiliaError.FromJson(jsonString);

namespace QuickType
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SessionCreationRequest
    {
        [JsonProperty("requestId")]
        public string RequestId { get; set; }

        [JsonProperty("users")]
        public UserProfileInfo[] Users { get; set; }
    }

    public partial class UserProfileInfo
    {
        [JsonProperty("avatarURL", NullValueHandling = NullValueHandling.Ignore)]
        public string AvatarUrl { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public partial class SessionCreationRequestResponse
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public partial class SocketConnectionInfo
    {
        [JsonProperty("sessionId")]
        public string SessionId { get; set; }
    }

    public partial class UserSessionEvent
    {
        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public partial class ScoresUpdateEvent
    {
        [JsonProperty("scores")]
        public UserScore[] Scores { get; set; }
    }

    public partial class UserScore
    {
        [JsonProperty("score")]
        public double Score { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public partial class UserConnectionStatusEvent
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public partial class NotificationFromSessionEvent
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("eventPayload", NullValueHandling = NullValueHandling.Ignore)]
        public string EventPayload { get; set; }
    }

    public partial class NotificationToSessionEvent
    {
        [JsonProperty("eventName")]
        public string EventName { get; set; }

        [JsonProperty("eventPayload", NullValueHandling = NullValueHandling.Ignore)]
        public string EventPayload { get; set; }
    }

    public partial class SessionStateInfo
    {
        [JsonProperty("authenticatedSpeakers")]
        public string[] AuthenticatedSpeakers { get; set; }

        [JsonProperty("connectedSpeakers")]
        public string[] ConnectedSpeakers { get; set; }

        [JsonProperty("requestsToSpeak")]
        public string[] RequestsToSpeak { get; set; }

        [JsonProperty("sessionName")]
        public string SessionName { get; set; }

        [JsonProperty("userScores")]
        public UserScore[] UserScores { get; set; }
    }

    public partial class DbUserProfileInfo
    {
        [JsonProperty("avatarUrl")]
        public string AvatarUrl { get; set; }

        [JsonProperty("displayName")]
        public string DisplayName { get; set; }

        [JsonProperty("userId")]
        public string UserId { get; set; }
    }

    public partial class OmiliaError
    {
        [JsonProperty("errorName")]
        public string ErrorName { get; set; }
    }

    public partial class SessionCreationRequest
    {
        public static SessionCreationRequest FromJson(string json) => JsonConvert.DeserializeObject<SessionCreationRequest>(json, QuickType.Converter.Settings);
    }

    public partial class SessionCreationRequestResponse
    {
        public static SessionCreationRequestResponse FromJson(string json) => JsonConvert.DeserializeObject<SessionCreationRequestResponse>(json, QuickType.Converter.Settings);
    }

    public partial class UserProfileInfo
    {
        public static UserProfileInfo FromJson(string json) => JsonConvert.DeserializeObject<UserProfileInfo>(json, QuickType.Converter.Settings);
    }

    public partial class SocketConnectionInfo
    {
        public static SocketConnectionInfo FromJson(string json) => JsonConvert.DeserializeObject<SocketConnectionInfo>(json, QuickType.Converter.Settings);
    }

    public partial class UserSessionEvent
    {
        public static UserSessionEvent FromJson(string json) => JsonConvert.DeserializeObject<UserSessionEvent>(json, QuickType.Converter.Settings);
    }

    public partial class ScoresUpdateEvent
    {
        public static ScoresUpdateEvent FromJson(string json) => JsonConvert.DeserializeObject<ScoresUpdateEvent>(json, QuickType.Converter.Settings);
    }

    public partial class UserConnectionStatusEvent
    {
        public static UserConnectionStatusEvent FromJson(string json) => JsonConvert.DeserializeObject<UserConnectionStatusEvent>(json, QuickType.Converter.Settings);
    }

    public partial class NotificationFromSessionEvent
    {
        public static NotificationFromSessionEvent FromJson(string json) => JsonConvert.DeserializeObject<NotificationFromSessionEvent>(json, QuickType.Converter.Settings);
    }

    public partial class NotificationToSessionEvent
    {
        public static NotificationToSessionEvent FromJson(string json) => JsonConvert.DeserializeObject<NotificationToSessionEvent>(json, QuickType.Converter.Settings);
    }

    public partial class UserScore
    {
        public static UserScore FromJson(string json) => JsonConvert.DeserializeObject<UserScore>(json, QuickType.Converter.Settings);
    }

    public partial class SessionStateInfo
    {
        public static SessionStateInfo FromJson(string json) => JsonConvert.DeserializeObject<SessionStateInfo>(json, QuickType.Converter.Settings);
    }

    public partial class DbUserProfileInfo
    {
        public static DbUserProfileInfo FromJson(string json) => JsonConvert.DeserializeObject<DbUserProfileInfo>(json, QuickType.Converter.Settings);
    }

    public partial class OmiliaError
    {
        public static OmiliaError FromJson(string json) => JsonConvert.DeserializeObject<OmiliaError>(json, QuickType.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SessionCreationRequest self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this SessionCreationRequestResponse self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this UserProfileInfo self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this SocketConnectionInfo self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this UserSessionEvent self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this ScoresUpdateEvent self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this UserConnectionStatusEvent self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this NotificationFromSessionEvent self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this NotificationToSessionEvent self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this UserScore self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this SessionStateInfo self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this DbUserProfileInfo self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        public static string ToJson(this OmiliaError self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
