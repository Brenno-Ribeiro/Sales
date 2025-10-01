# Etapa base - runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app

# Instalar dependências necessárias para System.Drawing (GDI+)
RUN apt-get update \
    && apt-get install -y libgdiplus libc6-dev \
    && ln -s /usr/lib/libgdiplus.so /usr/lib/libgdiplus.dll \
    && apt-get clean

EXPOSE 80

# Etapa build - SDK
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copia toda a solução
COPY . .

# Restaura pacotes
RUN dotnet restore "SalesSoftware.App/SalesSoftware.App.csproj"

# Build e publish
WORKDIR "/src/SalesSoftware.App"
RUN dotnet build "SalesSoftware.App.csproj" -c Release -o /app/build
RUN dotnet publish "SalesSoftware.App.csproj" -c Release -o /app/publish

# Etapa final
FROM base AS final
WORKDIR /app

# Copiar os arquivos publicados
COPY --from=build /app/publish .

# Copiar a pasta de relatórios
COPY SalesSoftware.App/Reports /app/Reports

# Definir variável de ambiente para System.Drawing
ENV DOTNET_SYSTEM_DRAWING_ENABLE_UNSAFE_FORMS_LIBS=true

ENTRYPOINT ["dotnet", "SalesSoftware.App.dll"]
