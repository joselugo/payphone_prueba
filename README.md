# 💳 Wallet API

API RESTful para la gestión de billeteras digitales, desarrollada con .NET 8 siguiendo los principios de **Clean Architecture**, **SOLID**, **EF Core**, **FluentValidation**, autenticación JWT y pruebas unitarias.

---

## 📦 Estructura del Proyecto (Clean Architecture)

```
WalletApi/
├── Wallet.API/             → Capa de presentación (controllers, middlewares)
├── Wallet.Application/     → Casos de uso, CQRS (Commands, Queries), validaciones
├── Wallet.Domain/          → Entidades y enums de dominio
├── Wallet.Infrastructure/  → EF Core, repositorios, configuración DB
├── Wallet.Tests/           → Pruebas unitarias (xUnit + Moq)
```

---

## 🚀 Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server Local
- Visual Studio 2022+ o VS Code

---

## 🔧 Clonar y ejecutar el proyecto

```bash
git clone https://github.com/joselugo/payphone_prueba.git

# Desde la terminal powershell en raiz, moverse a cada proyecto
#ejemplo

cd Wallet.API

# Restaurar paquetes
dotnet restore

# Crear la base de datos y aplicar migraciones
cd Wallet.API
dotnet ef database update
```

> Asegúrate de configurar correctamente la cadena de conexión en `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=WalletDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## ▶️ Ejecutar la API

```bash
dotnet run --project Wallet.API
```

Visita: [https://localhost:5001/swagger](https://localhost:5001/swagger)

---

## 🧪 Ejecutar pruebas unitarias

```bash
dotnet test
```

✅ Las pruebas están ubicadas en el proyecto `Wallet.Tests`, usando `xUnit` y `Moq`.

---

## 🔐 Autenticación (JWT)

### Credenciales por defecto:

```json
POST /api/auth/login

{
  "username": "admin",
  "password": "1234"
}
```

📥 Copia el token retornado y haz clic en el botón `Authorize` en Swagger. Usa:

```
Bearer tu_token_aqui
```

---

## 📂 Endpoints disponibles

| Método | Endpoint                       | Autenticado | Descripción                        |
|--------|--------------------------------|-------------|-------------------------------------|
| POST   | `/api/auth/login`              | ❌          | Obtener token JWT                  |
| POST   | `/api/wallet`                  | ✅          | Crear nueva billetera              |
| GET    | `/api/wallet`                  | ❌          | Listar todas las billeteras        |
| GET    | `/api/wallet/{id}`             | ✅          | Obtener una billetera por ID       |
| POST   | `/api/wallet/transfer`         | ✅          | Transferir saldo entre billeteras  |
| GET    | `/api/wallet/{id}/movements`   | ✅          | Ver movimientos de una billetera   |

---

## ✅ Tecnologías utilizadas

- ✅ ASP.NET Core 8
- ✅ MediatR (CQRS)
- ✅ Entity Framework Core
- ✅ SQL Server
- ✅ FluentValidation
- ✅ JWT Authentication
- ✅ Swagger / OpenAPI
- ✅ xUnit + Moq (tests)
