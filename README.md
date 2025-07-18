1. Instrukcja

W pliku appsettings.json należy ustawić poprawny serwer w sekcji ConnectionStrings.
Utworzyć bazę danych używając utworzonej już migracji.
Uruchomić aplikacje.

2.
Wybrałem architekturę WebApi w C# .Net 8.0, EntityFramework i bazę danych SQL w MSSQL.
Wybór w zasadzie opiera się na tym co umiem i czego się uczę w celu praktyki.

3. 
Kluczowe modele:
User: Prosty model użytkownika, który zawiera email, hasło, pole enum z Rolą oraz przypisaną listą zamówień(Order)
Order: Model zamówienia zawiera podstawowe informacje o zamówieniu i listę pozycji (OrderItems)
OrderItems: Pozycja zamówienia połączona z modelem Order, informuje ile i czego jest zamówione.
Delivery: Model raportowania zamówienia i potwierdzania przez klienta otrzymanych dostaw.

Query z przykładowymi danym do wrzucenia do bazy danych

-- USERS
INSERT INTO [User] (Id, email, password, Role) VALUES
('A1111111-1111-1111-1111-111111111111', 'client1@example.com', 'pass123', 'Client'),
('A1111111-1111-1111-1111-111111111112', 'client2@example.com', 'pass123', 'Client'),
('B2222222-2222-2222-2222-222222222221', 'supplier1@example.com', 'pass123', 'Supplier'),
('B2222222-2222-2222-2222-222222222222', 'supplier2@example.com', 'pass123', 'Supplier');

-- ORDERS
INSERT INTO [Order] (Id, ClientId, SupplierId, CreatedAt, Status) VALUES
('C3333333-3333-3333-3333-333333333331', 'A1111111-1111-1111-1111-111111111111', 'B2222222-2222-2222-2222-222222222221', '2025-07-01T08:00:00', 'Open'),
('C3333333-3333-3333-3333-333333333332', 'A1111111-1111-1111-1111-111111111112', 'B2222222-2222-2222-2222-222222222222', '2025-07-02T09:00:00', 'Closed');

-- ORDER ITEMS
INSERT INTO [OrderItem] (Id, OrderId, ProductName, Quantity) VALUES
('D4444444-4444-4444-4444-444444444441', 'C3333333-3333-3333-3333-333333333331', 'Blacha 2mm', 200),
('D4444444-4444-4444-4444-444444444442', 'C3333333-3333-3333-3333-333333333331', 'Rura fi 20', 120),
('D4444444-4444-4444-4444-444444444443', 'C3333333-3333-3333-3333-333333333332', 'Ceownik 30x30', 75),
('D4444444-4444-4444-4444-444444444444', 'C3333333-3333-3333-3333-333333333332', 'Pręt 12mm', 40);

-- DELIVERIES
INSERT INTO [Delivery] (Id, OrderItemId, QuantityDelivered, ShippedAt, ConfirmedByClient, ConfirmedAt) VALUES
('E5555555-5555-5555-5555-555555555551', 'D4444444-4444-4444-4444-444444444441', 100, '2025-07-03T08:30:00', 1, '2025-07-04T10:00:00'),
('E5555555-5555-5555-5555-555555555552', 'D4444444-4444-4444-4444-444444444442', 60, '2025-07-04T11:00:00', 0, NULL),
('E5555555-5555-5555-5555-555555555553', 'D4444444-4444-4444-4444-444444444443', 75, '2025-07-05T12:00:00', 1, '2025-07-06T09:00:00'),
('E5555555-5555-5555-5555-555555555554', 'D4444444-4444-4444-4444-444444444444', 20, '2025-07-06T15:00:00', 0, NULL);

