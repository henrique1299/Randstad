# Randstad Teste - Henrique Martins Furtado

## Métodos da API

#### Converter
  `GET https://{server}:{port}/api/Convert/{id1}-{id2}-{valor}`
   Sendo `id1` e `id2` os IDs referentes a `cryptocurrency-data-api` (exceto USD):
   
      "Bitcoin":"90";
      "Ethereum":"80"
      "Monero":"28"
      "Zcash":"134"
      "Ethereum Classic":"118";
      "Bitcoin Cash":"33234";
      "USD":"1";
    
## Implementação do site (front-end)

  Mudar a url em `Converter()` dentro de `scripts.js` para o endereço onde a API está localizada:
  `https://{servidor}:{porta}/api/Convert/`
