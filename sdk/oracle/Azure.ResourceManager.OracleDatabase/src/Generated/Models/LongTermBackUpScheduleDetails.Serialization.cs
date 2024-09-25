// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.OracleDatabase.Models
{
    public partial class LongTermBackUpScheduleDetails : IUtf8JsonSerializable, IJsonModel<LongTermBackUpScheduleDetails>
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer) => ((IJsonModel<LongTermBackUpScheduleDetails>)this).Write(writer, ModelSerializationExtensions.WireOptions);

        void IJsonModel<LongTermBackUpScheduleDetails>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LongTermBackUpScheduleDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LongTermBackUpScheduleDetails)} does not support writing '{format}' format.");
            }

            if (Optional.IsDefined(RepeatCadence))
            {
                writer.WritePropertyName("repeatCadence"u8);
                writer.WriteStringValue(RepeatCadence.Value.ToString());
            }
            if (Optional.IsDefined(BackupOn))
            {
                writer.WritePropertyName("timeOfBackup"u8);
                writer.WriteStringValue(BackupOn.Value, "O");
            }
            if (Optional.IsDefined(RetentionPeriodInDays))
            {
                writer.WritePropertyName("retentionPeriodInDays"u8);
                writer.WriteNumberValue(RetentionPeriodInDays.Value);
            }
            if (Optional.IsDefined(IsDisabled))
            {
                writer.WritePropertyName("isDisabled"u8);
                writer.WriteBooleanValue(IsDisabled.Value);
            }
            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var item in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(item.Key);
#if NET6_0_OR_GREATER
				writer.WriteRawValue(item.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(item.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        LongTermBackUpScheduleDetails IJsonModel<LongTermBackUpScheduleDetails>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LongTermBackUpScheduleDetails>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(LongTermBackUpScheduleDetails)} does not support reading '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeLongTermBackUpScheduleDetails(document.RootElement, options);
        }

        internal static LongTermBackUpScheduleDetails DeserializeLongTermBackUpScheduleDetails(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= ModelSerializationExtensions.WireOptions;

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            RepeatCadenceType? repeatCadence = default;
            DateTimeOffset? timeOfBackup = default;
            int? retentionPeriodInDays = default;
            bool? isDisabled = default;
            IDictionary<string, BinaryData> serializedAdditionalRawData = default;
            Dictionary<string, BinaryData> rawDataDictionary = new Dictionary<string, BinaryData>();
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("repeatCadence"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    repeatCadence = new RepeatCadenceType(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("timeOfBackup"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    timeOfBackup = property.Value.GetDateTimeOffset("O");
                    continue;
                }
                if (property.NameEquals("retentionPeriodInDays"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    retentionPeriodInDays = property.Value.GetInt32();
                    continue;
                }
                if (property.NameEquals("isDisabled"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    isDisabled = property.Value.GetBoolean();
                    continue;
                }
                if (options.Format != "W")
                {
                    rawDataDictionary.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }
            serializedAdditionalRawData = rawDataDictionary;
            return new LongTermBackUpScheduleDetails(repeatCadence, timeOfBackup, retentionPeriodInDays, isDisabled, serializedAdditionalRawData);
        }

        BinaryData IPersistableModel<LongTermBackUpScheduleDetails>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LongTermBackUpScheduleDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options);
                default:
                    throw new FormatException($"The model {nameof(LongTermBackUpScheduleDetails)} does not support writing '{options.Format}' format.");
            }
        }

        LongTermBackUpScheduleDetails IPersistableModel<LongTermBackUpScheduleDetails>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<LongTermBackUpScheduleDetails>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeLongTermBackUpScheduleDetails(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(LongTermBackUpScheduleDetails)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<LongTermBackUpScheduleDetails>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
