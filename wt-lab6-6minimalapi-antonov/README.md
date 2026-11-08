# WT-6 Minimal API — Прокат автомобилей

## Таблица API
| Метод | URL | Назначение | Статус успеха |
| :--- | :--- | :--- | :--- |
| GET | `/api/cars` | Получить список всех авто | 200 OK |
| GET | `/api/cars/{id}` | Получить авто по ID | 200 OK / 404 |
| GET | `/api/cars/search?search=BMW` | Фильтр по марке | 200 OK |
| POST | `/api/cars` | Создать авто | 201 Created |
| PUT | `/api/cars/{id}` | Обновить авто | 200 OK / 404 |
| DELETE | `/api/cars/{id}` | Удалить авто | 204 No Content / 404 |

## Пример JSON-запроса (POST/PUT):
{
  "brand": "Lada",
  "model": "Vesta",
  "year": 2023,
  "pricePerDay": 2000,
  "isAvailable": true
}
<!-- Проверка автоматического деплоя -->
