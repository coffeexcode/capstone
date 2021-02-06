# Event Management API
Microservice to support managing subscriber hosted events

# Building
## Running in Docker
1. Navigate to the source directory where to Dockerfile is located

2. Build the docker image
```bash
docker build -f Dockerfile .. -t eventmanagement-api-demo:latest 
```

3. Run the docker container
```bash
docker run --rm -p 5000:80 --name demo1 -e ASPNETCORE_ENVIRONMENT=Development eventmanagement-api-demo
```

4. Application is available at http://localhost:5000

5. Optionally, view swagger at http://localhost:5000/swagger