# SnapShop

Микросервисы и их ответственность:

Product Service (Port 5001) - управление каталогом товаров, категориями и остатками

Order Service (Port 5002) - обработка заказов и управление жизненным циклом заказов

Cart Service (Port 5003) - функциональность корзины покупок с Redis storage

User Service (Port 5004) - управление пользователями, аутентификация и авторизация

Payment Service (Port 5005) - обработка платежей с интеграцией Stripe

Notification Service (Port 5006) - email и SMS уведомления

Каждый сервис использует Clean Architecture с четким разделением слоев: Controllers, Services, Data Access, и Models. Это обеспечивает maintainability, testability и loose coupling между компонентами.

