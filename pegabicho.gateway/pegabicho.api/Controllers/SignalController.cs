using Microsoft.AspNetCore.Mvc;
using pegabicho.api.Controllers.Base;

namespace pegabicho.api.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class SignalController : CoreController {

        //private void AuctionProduct_OnStart(AuctionProduct product) {
        //    hub.Clients.All.SendAsync("AuctionProduct_OnStart", JsonConvert.SerializeObject(product));
        //}

        //private void AuctionProduct_OnBidOffered(Bid bid) {
        //    hub.Clients.Group(bid.AuctionProduct.Id.ToString()).SendAsync("AuctionProduct_OnBidOffered", JsonConvert.SerializeObject(bid));
        //}

        //private void AuctionProduct_OnTick(AuctionProduct product) {
        //    var response = (AuctionProductResponse)product;
        //    hub.Clients.Group(product.Id.ToString()).SendAsync("AuctionProduct_OnTick", JsonConvert.SerializeObject(product));
        //}

        //private void AuctionProduct_OnEnd(AuctionProduct product) {

        //    hub.Clients.Group(product.Id.ToString()).SendAsync("AuctionProduct_OnEnd", JsonConvert.SerializeObject(product));

        //    _auctionProductRepo.UpdateAuctionProductStatus(product.Id, (int)AuctionProductStatus.Ended);

        //    _log.Add(new Log(JsonConvert.SerializeObject(product), product.Auction.ProjectId, RequestIp(), LogType.OK, "EndAuctionProduct"));

        //    SendAuctionProductToProject(product);
        //}
    }
}