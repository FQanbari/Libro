using Application.Interfaces;
using Application.Throtting;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebAPI.Controllers.Api;
using WebAPI.Model;

namespace WebAPI.Controllers;

public class MemeberController : ApiBaseController
{
    private readonly IMemberService _memberservice;
    private readonly IOTPService _otp;
    private readonly ISMSService _sms;
    private readonly IJWTService _jwt;
    private readonly IThrottler _throttler;
    private readonly IMembershipService _memberShipService;

    public MemeberController(IMemberService memberservice, IOTPService opt, ISMSService sms, 
        IJWTService jwt, IThrottler throttler, IMembershipService membershipService)
    {
        this._memberservice = memberservice;
        _otp = opt;
        _sms = sms;
        _jwt = jwt;
        _throttler = throttler;
        _memberShipService = membershipService;
    }
    
    [HttpGet]
    public async Task<string> Otp([FromQuery] string phone)
    {
        if (!(await _throttler.TryGet()))
            throw new Exception("You Can't Login. try another time");

        var otp = await _otp.GenerateOtp(phone);
        await _sms.SendSms(phone, $"Your verfiy code is: {otp}");
        return otp;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequestModel model)
    {
        if (!(await _otp.VerifyOtp(model.PhoneNumber, model.Otp)))
            throw new Exception("your verify code is not valid.");

        var token = await _jwt.GenerateToken(model.PhoneNumber);

        return Ok(token);
    }
    [HttpGet]
    public async Task InvalidToken([FromQuery] string phone, [FromHeader] string token)
    {

        _jwt.InvalidateToken(phone, token);
    }

    [HttpPost]
    public async Task<IActionResult> Signin([FromBody] RegisterRequestModel model)
    {
        // TODO: Signin
        return Ok();
    }

    [HttpPost]
    public async Task PremiumMembership()
    {
        _memberShipService.Premium(User.Id());
    }
}
