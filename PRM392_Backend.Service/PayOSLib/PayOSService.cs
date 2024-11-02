using Net.payOS;
using Net.payOS.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRM392_Backend.Service.PayOSLib
{
    public class PayOSService
    {
        private readonly PayOS _payOS;

        public PayOSService(string clientId, string apiKey, string checksumKey)
        {
            _payOS = new PayOS(clientId, apiKey, checksumKey);
        }

        public async Task<CreatePaymentResult> CreatePaymentLink(PaymentData paymentData)
        {
            return await _payOS.createPaymentLink(paymentData);
        }

        public async Task<PaymentLinkInformation> GetPaymentLinkInformation(long orderCode)
        {
            return await _payOS.getPaymentLinkInformation(orderCode);
        }

        public async Task<PaymentLinkInformation> CancelPaymentLink(int paymentId)
        {
            return await _payOS.cancelPaymentLink(paymentId);
        }

        public async Task<string> ConfirmWebhook(string webhookUrl)
        {
            return await _payOS.confirmWebhook(webhookUrl);
        }

        public WebhookData VerifyPaymentWebhookData(WebhookType webhookBody)
        {
            return _payOS.verifyPaymentWebhookData(webhookBody);
        }
    }
}
