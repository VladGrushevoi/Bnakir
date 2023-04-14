using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ShkliftApplication.Features.TransactionFeature.CreateTransaction;

public record CreateTransactionRequest : IRequest<CreateTransactionResponse>
{
    [Required]
    [RegularExpression("\\d{16}", ErrorMessage = "Card number must be contain 16 letters")]
    public string FromCardNumber { get; set; }
    
    [Required]
    [RegularExpression("\\d{3}", ErrorMessage = "Card CVV must be contain 3 letters")]
    public string FromCardCVV { get; set; }
    
    [Required]
    [RegularExpression("\\d{4}-\\d{2}-\\d{2}", ErrorMessage = "Date must be equal to patter yyyy-mm-dd")]
    public string FromCardExpire { get; set; }
    
    [Required]
    [Range(5, float.MaxValue, ErrorMessage = "Amount money must be greater then 5")]
    public float AmountMoney { get; set; }
    
    // [Required]
    // [Range(1, float.MaxValue, ErrorMessage = "Commission must be greater then 1")]
    // public float Commission { get; set; }
    
    [Required]
    [RegularExpression("\\d{16}", ErrorMessage = "Card CVV must be contain 3 letters")]
    public string CardNumberReceiver { get; set; }
}