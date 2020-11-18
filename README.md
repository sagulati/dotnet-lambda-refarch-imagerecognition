# dotnet-lambda-refarch-imagerecognition
The Image Recognition and Processing Backend reference architecture demonstrates how to use AWS Step Functions to orchestrate a serverless processing workflow using AWS Lambda, Amazon S3, Amazon DynamoDB and Amazon Rekognition.

 aws cloudformation create-stack --stack-name public-cloudfront-for-s3  --template-body file://cloudfront-s3.yaml --parameters ParameterKey=OAIEnabled,ParameterValue=yes ParameterKey=S3BucketName,ParameterValue=blazor-image-recognition-web
