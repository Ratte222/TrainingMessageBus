# Quick start
	- run command 
``` docker
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.10-management
```
	this command will download and run docker image with RabbitMQ. You can go to `http://localhost:15672` and enter into 
	user interface. Use `guest` in Username and Password fields.
	You also may use [this example](https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html)
	- Then you may run "TrainingMessageBus" project and use endpoint
