# Microservices Sample

Microservices sample with a SPA Angular front end and several ASP.NET Core Web API back ends. The front end communicates with the back ends via an API Gateay und synchronous HTTP. The microservices talk to each other via asynchronous RabbitMQ messaging.

## Run

Run the following `docker-compose` command in the `/docker` folder:

```bash
$ docker-compose -f docker-compose.yaml -f docker-compose-infrastructure.yaml up --build
```

## Usage

### Angular front end

Launch a browser on http://localhost:80.

### Notes Web-API

Make HTTP requests to `localhost:5000`, for example:

```bash
curl -X GET http://localhost:5000/api/v1/notes
curl -X GET http://localhost:5000/api/v1/notes/note-id
curl -X POST http://localhost:5000/api/v1/notes -H "Content-Type: application/json" -d '{ "text": "This is a text.", "author": "Jan Bohlen" }'

```

## Architecture Guidance

- https://martinfowler.com/articles/microservices.html
- https://www.youtube.com/watch?v=wgdBVIX9ifA
- https://docs.microsoft.com/en-us/dotnet/standard/microservices-architecture/index

## License

MIT License

Copyright (c) 2017 eposgmbh

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
