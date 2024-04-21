
# Exploring-RabbitMQ-Publish-Subscribe

This Project Demonstrates the Messaing-Queue Implementation Using RabbitMQ in C#
## Explaination

Here I've created 2 Console Projects **( Producer & Consumer )** for the demonstration of **Pub-Sub ( Publish & Subscribe ) of RabbitMQ**

## Common Functionality
Common Functionality class library holds the common function like models, Queue's and Channel Declaration for pub/Sub

## Producer

Here, In Producer first we **Declare the Exchange and its type ( Direct, fanout, etc )** then we **Declare Queue and bind it with Exchange along with its routing key** and then we get the Comments from Comments API which is declared in common function library and serialize the object into json format, then **encodes the json format object into bytes of array, inorder to Publish the message into the queue**

## Consumer

Here, In Consumer we do the same thing Declaring Exchange & Queue and Bind It together. after this, **new instance of EventingBasicConsumer is created, in this object we have Received Delegate which is a callback function using which we can Subscribe the messages which are Enqueued in the Queue**




## Authors

- [@krishnasonune87](https://www.github.com/octokatherine)

