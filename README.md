# MicroserviceArchitecture
An example implementation of a microservice-based architecture.

## Client Applications
- **Blazor WebAssembly (WASM)**: Web client.  
  - Client application follow the **FSD (Feature-Sliced Design) architecture**.
  - A component library is used MudBlazor
- **MAUI Blazor**: Cross-platform mobile clients for Android and iOS.
  - Client application follow the **Vertical architecture**.
  - A component library is used Radzen.Blazor

## Technologies
- **Docker**: Containerization of services.  
- **Apache Kafka**: Message broker for event-driven communication.  
- **PostgreSQL**: Relational database for persistent storage.