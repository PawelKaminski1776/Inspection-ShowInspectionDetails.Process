using NServiceBus;

namespace InspectionShowInspectionDetails.Messages.Dtos
{
    public class MessageRequest : IMessage
    {
        public string Message { get; set; }
    }

    public class MessageResponse : IMessage
    {
        public string Message { get; set; }
    }
    public class ShowInspectionDetailsRequest : IMessage
    {
        public string Email { get; set; }
    }

    public class ShowInspectionDetailsResponse : IMessage
    {
        public List<ImageTraining> data { get; set; }
    }

    public class ImageTraining
    {
        public string id { get; set; }
        public string Inspectionname { get; set; }

        public string county { get; set; }
        public string NumOfImages { get; set; }

        public string overalllossrate { get; set; }
        public string status { get; set; }
    }

}
