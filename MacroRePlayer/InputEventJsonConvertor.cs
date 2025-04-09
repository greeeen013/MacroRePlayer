using MacroRePlayer;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

class InputEventConverter : JsonConverter<IInputEvent>
{
    public override IInputEvent? ReadJson(JsonReader reader, Type objectType, IInputEvent? existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        var jsonObject = JObject.Load(reader);
        var type = jsonObject["Type"]?.ToString() ?? "";
        IInputEvent inputEvent = type switch
        {
            "DelayEvent" => new DelayEvent(),
            "MouseDown" => new MouseDownEvent(),
            "MouseUp" => new MouseUpEvent(),
            "KeyDown" => new KeyDownEvent(),
            "KeyUp" => new KeyUpEvent(),
            _ => throw new Exception("Unknown type"),
        };
        serializer.Populate(jsonObject.CreateReader(), inputEvent);
		return inputEvent;
	}

    public override void WriteJson(JsonWriter writer, IInputEvent? value, JsonSerializer serializer)
    {
        if (value == null)
        {
            writer.WriteNull();
        }
        else
        {
            serializer.Serialize(writer, value);
        }
    }
}