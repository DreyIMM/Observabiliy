![image](https://github.com/user-attachments/assets/c19bc4ac-da7a-48c1-b7ed-f2305678918a)
![image](https://github.com/user-attachments/assets/341c7a97-93e3-4718-bde4-7fbfef01fad1)


# Observabilidade com .NET 6.0 e Docker

Este repositório apresenta um exemplo prático de implementação dos pilares da observabilidade (“Logs”, “Métricas” e “Tracing”) em uma aplicação .NET 6.0, utilizando contêineres Docker para configurar ferramentas como Elasticsearch, Kibana, Prometheus e Grafana.

---

## Arquitetura do Projeto

A arquitetura consiste nos seguintes serviços:

1. **SQL Server**: Banco de dados para armazenar as informações da aplicação.
2. **Elasticsearch**: Banco de dados para armazenar logs estruturados.
3. **Kibana**: Interface gráfica para visualização e análise dos logs coletados.
4. **Prometheus**: Ferramenta para coleta e armazenamento de métricas em séries temporais.
5. **Grafana**: Plataforma de visualização para métricas e criação de dashboards interativos.
6. **Aplicação ASP.NET Core**: A aplicação em si, configurada para expor métricas e gerar logs.

Kibana

![image](https://github.com/user-attachments/assets/93f8227c-3990-4ae1-b63a-6ea6f0b82991)



Grafana

![image](https://github.com/user-attachments/assets/774bf224-93fb-4bcc-8328-79d03b23d3bb)


---

## Requisitos

Certifique-se de ter os seguintes requisitos instalados no seu ambiente:

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/)

---

## Como Rodar o Projeto

1. **Clone o repositório**:

   ```bash
   git clone https://github.com/seu-usuario/seu-repositorio.git
   cd seu-repositorio
   ```

2. **Suba os contêineres com Docker Compose**:

   ```bash
   docker-compose up -d
   ```

3. **Acesse os serviços**:

   - **Kibana**: [http://localhost:5601](http://localhost:5601)
   - **Prometheus**: [http://localhost:9090](http://localhost:9090)
   - **Grafana**: [http://localhost:3000](http://localhost:3000)
     - **Usuário**: `admin`
     - **Senha**: `admin`
   - **Aplicação ASP.NET Core**: [http://localhost:8080](http://localhost:8080)

---

## Configurações Importantes

### **Prometheus**

O arquivo `prometheus.yml` está configurado para coletar métricas da própria instância do Prometheus e da aplicação ASP.NET Core:

```yaml
global:
  scrape_interval: 15s

scrape_configs:
  - job_name: 'prometheus'
    static_configs:
      - targets: ['prometheus:9090']

  - job_name: 'csharp-app'
    static_configs:
      - targets: ['observability-aspnetapp:8080']
    metrics_path: /metrics
```

### **Grafana**

O arquivo `grafana_datasources.yaml` configura automaticamente o Prometheus como fonte de dados para o Grafana:

```yaml
datasources:
  - name: "prometheus"
    type: "prometheus"
    access: "proxy"
    url: "http://prometheus:9090"
```

### **Aplicação ASP.NET Core**

A aplicação está configurada para expor métricas no endpoint `/metrics`, compatíveis com o Prometheus.

---

## Estrutura do Repositório

```
/
|-- Observability/
|   |-- src/
|       |-- sql/           # Configurações do SQL Server
|       |-- app/           # Código-fonte da aplicação .NET
|-- docker-compose.yml     # Arquivo de orquestração do Docker
|-- prometheus.yml         # Configuração do Prometheus
|-- grafana_datasources.yaml # Configuração das fontes de dados do Grafana
```

---

## Recursos Adicionais

- [Documentação do Docker](https://docs.docker.com/)
- [Prometheus](https://prometheus.io/docs/introduction/overview/)
- [Grafana](https://grafana.com/docs/)
- [Elasticsearch](https://www.elastic.co/guide/en/elasticsearch/reference/current/index.html)
- [Kibana](https://www.elastic.co/guide/en/kibana/current/index.html)

---

## Contribuições

Sinta-se à vontade para abrir issues e enviar pull requests para melhorias ou correções.

---

## Licença

Este projeto está licenciado sob a [Licença MIT](LICENSE).

