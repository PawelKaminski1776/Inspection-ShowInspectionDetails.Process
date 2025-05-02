using InspectionShowInspectionDetails.Channel.Services;
using InspectionShowInspectionDetails.Messages.Dtos;

namespace InspectionShowInspectionDetails.Handlers
{
    public class MyHandler : IHandleMessages<ShowInspectionDetailsRequest>
    {
        private readonly UserService _userService;
        private readonly InspectionDetailsService _inspectionDetailsService;
        public MyHandler(InspectionDetailsService inspectionDetailsService, UserService userService)
        {
            this._inspectionDetailsService = inspectionDetailsService;
            this._userService = userService;
        }

        public async Task Handle(ShowInspectionDetailsRequest message, IMessageHandlerContext context)
        {
            try
            {
                var userexists = await _userService.CheckIfUserExists(message);

                ShowInspectionDetailsResponse response = new ShowInspectionDetailsResponse();
                response.data = new List<ImageTraining>();

                if (userexists == "User Not Found")
                {
                    await context.Reply(response);
                }
                else
                {
                    var allDetails  = await _inspectionDetailsService.GetAllModels();
                    if(allDetails == null)
                    {
                        await context.Reply(response);
                    }
                    else
                    {
                        foreach (var detail in allDetails)
                        {
                            var modelDetails = new ImageTraining
                            {
                                id = detail.GetValue("id").AsString,
                                Inspectionname = detail.GetValue("Inspectionname").AsString,
                                county = detail.GetValue("County").AsString,
                                NumOfImages = detail.GetValue("NumberOfImages").AsString,
                                overalllossrate = detail.GetValue("Overall Training Loss Rate").AsString,
                                status = detail.GetValue("Status").AsString
                            };

                            response.data.Add(modelDetails);
                        }
                        await context.Reply(response);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while processing the message: {ex.Message}");

                throw;
            }
        }
    }
}
