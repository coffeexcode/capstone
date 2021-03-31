# Attendance API
Microservice to support recording "attendance" events throughout a conference

# Building
## Running in Docker
1. Navigate to the source directory where to Dockerfile is located

2. Build the docker image
```bash
docker build -f Dockerfile .. -t attendance-api-demo:latest 
```

3. Run the docker container
```bash
docker run --rm -p 5000:80 --name demo1 -e ASPNETCORE_ENVIRONMENT=Development attendance-api-demo
```

4. Application is available at http://localhost:5000

5. Optionally, view swagger at http://localhost:5000/swagger

# Documentation
Source code is documented using C# / ASP.Net core API standards. For interactive exploration using a UI,
please run the API in a development environment (see above instructions) and view the Swagger documentation
using a browser. For more information about Swagger, please see [https://swagger.io/tools/swagger-ui/](https://swagger.io/tools/swagger-ui/)