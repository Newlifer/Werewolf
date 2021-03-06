﻿using System;
using Newtonsoft.Json;
using Telegram.Bot.Types.Enums;

namespace Telegram.Bot.Types
{
    /// <summary>
    /// This object represents an incoming update.
    /// </summary>
    /// <remarks>
    /// Only one of the optional parameters can be present in any given update.
    /// </remarks>
    [JsonObject(MemberSerialization.OptIn)]
    public class Update
    {
        /// <summary>
        /// The update‘s unique identifier. Update identifiers start from a certain positive number and increase sequentially.
        /// This ID becomes especially handy if you’re using Webhooks, since it allows you to ignore repeated updates or to
        /// restore the correct update sequence, should they get out of order.
        /// </summary>
        [JsonProperty("update_id", Required = Required.Always)]
        public int Id { get; internal set; }

        /// <summary>
        /// Optional. New incoming message of any kind — text, photo, sticker, etc.
        /// </summary>
        [JsonProperty("message", Required = Required.Default)]
        public Message Message { get; internal set; }

        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        [JsonProperty("edited_message", Required = Required.Default)]
        public Message EditedMessage { get; internal set; }

        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        [JsonProperty("edited_channel_post", Required = Required.Default)]
        public Message EditedChannelPost { get; internal set; }

        /// <summary>
        /// Optional. New version of a message that is known to the bot and was edited
        /// </summary>
        [JsonProperty("channel_post", Required = Required.Default)]
        public Message ChannelPost { get; internal set; }

        /// <summary>
        /// Optional. New incoming inline query
        /// </summary>
        [JsonProperty("inline_query", Required = Required.Default)]
        public InlineQuery InlineQuery { get; internal set; }

        /// <summary>
        /// Optional. The result of a inline query that was chosen by a user and sent to their chat partner
        /// </summary>
        [JsonProperty("chosen_inline_result", Required = Required.Default)]
        public ChosenInlineResult ChosenInlineResult { get; internal set; }

        /// <summary>
        /// Optional. New incoming callback query
        /// </summary>
        [JsonProperty("callback_query", Required = Required.Default)]
        public CallbackQuery CallbackQuery { get; internal set; }

        [JsonIgnore]
        public UpdateType Type
        {
            get
            {
                if (Message != null)            return UpdateType.MessageUpdate;
                if (InlineQuery != null)        return UpdateType.InlineQueryUpdate;
                if (ChosenInlineResult != null) return UpdateType.ChosenInlineResultUpdate;
                if (CallbackQuery != null)      return UpdateType.CallbackQueryUpdate;
                if (EditedMessage != null)      return UpdateType.EditedMessage;
                if (EditedChannelPost != null)  return UpdateType.EditedChannelPost;
                if (ChannelPost != null)        return UpdateType.ChannelPost;
                throw new ArgumentOutOfRangeException();
            }
        }

        public static Update FromString(string data)
        {
            return JsonConvert.DeserializeObject<Update>(data);
        }
    }
}
