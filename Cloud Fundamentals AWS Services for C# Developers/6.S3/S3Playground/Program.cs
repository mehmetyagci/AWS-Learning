using System.Text;
using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();

/* Writing to s3 Part start
await using var inputStream = new FileStream("./movies.csv", FileMode.Open, FileAccess.Read);

var putObjectRequest = new  PutObjectRequest{
    BucketName = "mehmetyagci53bucket",
    Key = "files/movies.csv",
    ContentType = "text/csv",
    InputStream = inputStream
};

await s3Client.PutObjectAsync(putObjectRequest);
System.Console.WriteLine("Finished!");
   Writing to s3 Part end */

/// Reading from s3 part start

var getObjectResult = new GetObjectRequest{
    BucketName = "mehmetyagci53bucket",
    Key = "files/movies.csv",
};

var response = await s3Client.GetObjectAsync(getObjectResult);

using var memoryStream = new MemoryStream();
response.ResponseStream.CopyTo(memoryStream);

var text = Encoding.Default.GetString(memoryStream.ToArray());

Console.WriteLine(text);





/// Reading from s3 part end