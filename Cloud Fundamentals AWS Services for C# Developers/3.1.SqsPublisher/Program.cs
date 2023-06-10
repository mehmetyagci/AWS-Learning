﻿using Amazon.SQS;
using Amazon.SQS.Model;
using System.Text.Json;

var sqsClient = new AmazonSQSClient();

var customer = new CustomerCreated {
    Id = Guid.NewGuid(),
    Email = "mehmetyagci53@gmail.com",
    FullName = "Mehmet Yağcı",
    DateOfBirth = new DateTime(1982, 1, 1),
    GitHubUsername = "mehmetyagci",
};

var queueUrlResponse = await sqsClient.GetQueueUrlAsync("customers");

var sendMessageRequest = new SendMessageRequest {
    QueueUrl = queueUrlResponse.QueueUrl,
    MessageBody = JsonSerializer.Serialize(customer),
    MessageAttributes = new Dictionary<string, MessageAttributeValue> {
            {
                "MessageType", new MessageAttributeValue
                {
                    DataType = "String",
                    StringValue = nameof(CustomerCreated)
                }
            }
        }
};

var response = await sqsClient.SendMessageAsync(sendMessageRequest);

Console.WriteLine($"{response.MessageId} {response.HttpStatusCode} {response.ResponseMetadata}");

Console.ReadLine();





