# Gest�o de Lugares

Este projeto possibilita o usu�rio Criar, Editar, Excluir, Pesquisar, sendo a pesquisa geral ou por nome. 

## Pr�-Requisitos


```bash
docker
```

ou

```bash
.Net Core 2.2
```

## Buildar utilizando o Docker
Abrir o diret�rio raiz do projeto e rodar o seguinte comando no terminal
```bash
docker build -t place --build-arg deploy_env='dev' . && docker run -p 8080:8080 place
```

## Documenta��o
Ao Buildar a aplica��o, localhost:{{Porta}}/swagger, exemplo:
```bash
https://localhost:5001/swagger
```

## Postman
O Postman Collection e o Postman Environment est�o no diret�rio
PostmanCollection_Env

## GitHub
[@flaviodmussio](https://github.com/flaviodmussio/place)