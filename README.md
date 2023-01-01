# stock-api

.Net 6 ile Stocks tablosundan sorgular yapabilen bir Web Api projesidir.

PostgreSql
EntityFramework
Repository Pattern
Swagger


POST | api/stocks/ Ilgili variant listesini kaydeder.

[
  {
    "variantCode": "string",
    "productCode": "string",
    "quantity": 0
  }
]

api/stocks/{variantCode}?quantity=2 İlgili variantın stoğunu günceller

quantity : int

api/stocks/{variantCode}/variant İlgili variant için stok bilgilerini verir
api/stocks/{productCode}/product ilgili product için stok bilgilerini verir
