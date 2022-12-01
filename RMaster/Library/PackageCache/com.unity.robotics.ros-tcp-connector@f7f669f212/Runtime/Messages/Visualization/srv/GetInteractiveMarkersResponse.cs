//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Visualization
{
    [Serializable]
    public class GetInteractiveMarkersResponse : Message
    {
        public const string k_RosMessageName = "visualization_msgs/GetInteractiveMarkers";
        public override string RosMessageName => k_RosMessageName;

        //  Sequence number.
        //  Set to the sequence number of the latest update message
        //  at the time the server received the request.
        //  Clients use this to detect if any updates were missed.
        public ulong sequence_number;
        //  All interactive markers provided by the server.
        public InteractiveMarkerMsg[] markers;

        public GetInteractiveMarkersResponse()
        {
            this.sequence_number = 0;
            this.markers = new InteractiveMarkerMsg[0];
        }

        public GetInteractiveMarkersResponse(ulong sequence_number, InteractiveMarkerMsg[] markers)
        {
            this.sequence_number = sequence_number;
            this.markers = markers;
        }

        public static GetInteractiveMarkersResponse Deserialize(MessageDeserializer deserializer) => new GetInteractiveMarkersResponse(deserializer);

        private GetInteractiveMarkersResponse(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.sequence_number);
            deserializer.Read(out this.markers, InteractiveMarkerMsg.Deserialize, deserializer.ReadLength());
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.sequence_number);
            serializer.WriteLength(this.markers);
            serializer.Write(this.markers);
        }

        public override string ToString()
        {
            return "GetInteractiveMarkersResponse: " +
            "\nsequence_number: " + sequence_number.ToString() +
            "\nmarkers: " + System.String.Join(", ", markers.ToList());
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}