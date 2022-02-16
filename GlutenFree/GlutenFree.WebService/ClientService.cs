using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using GlutenFreeApp.WebService.Constants;

namespace GlutenFreeApp.WebService
{
    public class ClientService
    {
        static readonly string accessKey = Strings.accessKey;
        static readonly string secretKey = Strings.secretKey;

        static readonly AWSCredentials credentials = new BasicAWSCredentials(accessKey, secretKey);

        public static AmazonS3Client CreateS3Client()
        {
            AmazonS3Client s3Client = new AmazonS3Client(credentials, RegionEndpoint.EUCentral1);
            return s3Client;
        }
    }
}
