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

        IInputEvent inputEvent;

		switch (type)
		{
			case "DelayEvent":
				inputEvent = new DelayEvent();
				break;
			case "MouseDown":
				inputEvent = new MouseDownEvent();
				break;
			case "MouseUp":
				inputEvent = new MouseUpEvent();
				break;
			case "KeyDown":
				inputEvent = new KeyDownEvent();
				break;
			case "KeyUp":
				inputEvent = new KeyUpEvent();
				break;
			default:
				throw new Exception("Unknown type");
		}
		
		serializer.Populate(jsonObject.CreateReader(), inputEvent);
		return inputEvent;
	}

    public override void WriteJson(JsonWriter writer, IInputEvent value, JsonSerializer serializer)
    {
		serializer.Serialize(writer, value);
    }
}