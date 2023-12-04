using MassTransit;
using Model;
using Newtonsoft.Json;

internal class OrderConsumer : IConsumer<Order>
{
    public async Task Consume(ConsumeContext<Order> context)
    {
        await Console.Out.WriteLineAsync((context.Message.IssuingVendor));


        //try
        //{
        //    var lien = await _accountLienService.Add(new CreateLienDto
        //    {
        //        AccountNumber = context.Message.AccountNumber,
        //        Amount = context.Message.Amount,
        //        Description = context.Message.Description,
        //        StartDate = context.Message.StartDate,
        //        EndDate = context.Message.EndDate,
        //        LienCode = context.Message.LienCode,
        //        BranchCode = context.Message.BranchCode,
        //        Status = true
        //    });
        //    await context.RespondAsync<BaseResponseVM<AccountLienInfoModel>>(lien);
        //}
        //catch (Exception ex)
        //{
        //    ex.LogError();
        //    await context.RespondAsync<BaseResponseVM<AccountLienInfoModel>>(_baseResponse.InternalServerError(ex));
        //}
    }
}
