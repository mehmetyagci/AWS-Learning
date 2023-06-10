using Amazon.SQS;
using Amazon.SQS.Model;

var cts = new CancellationTokenSource();
var sqsClient = new AmazonSQSClient();

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var receiveMessageRequest = new ReceiveMessageRequest {
    QueueUrl = queueUrlResponse.QueueUrl,
    AttributeNames= new List<string> { "All"},  // adding Attributes to the message
    MessageAttributeNames = new List<string> { "All" } // adding MessageAttributes to the message
};


while (!cts.IsCancellationRequested) {
    var response = await sqsClient.ReceiveMessageAsync(receiveMessageRequest, cts.Token);

    foreach (var message in response.Messages) {
        Console.WriteLine($"Message Id: {message.MessageId}");
        Console.WriteLine($"Messaage Body: {message.Body}");

        // Deleting messages
        var deleteMessageResponse = await sqsClient.DeleteMessageAsync(queueUrlResponse.QueueUrl, message.ReceiptHandle); 
    }
    await Task.Delay(1000);
}