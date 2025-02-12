--------------------------------------------------
-- 1. Tworzenie bazy danych
--------------------------------------------------
-- tylko jeśli nie istnieje
IF DB_ID('ATM_DB') IS NULL
BEGIN
    CREATE DATABASE ATM_DB;
END
GO

-- Użycie bazy danych ATM_DB
USE ATM_DB;
GO

--------------------------------------------------
-- 2. Tworzenie tabel
--------------------------------------------------

-- Tabela PaymentCards – przechowuje dane kart płatniczych
CREATE TABLE PaymentCards (
    CardNumber VARCHAR(20) PRIMARY KEY,      -- Numer karty (unikalny)
    PIN VARCHAR(10) NOT NULL,                -- Kod PIN
    PaymentSystem VARCHAR(50) NOT NULL,      -- System kartowy (np. Visa, AmericanExpress, VisaElectron, Mastercard)
    FailedAttempts INT NOT NULL DEFAULT 0,   -- Liczba nieudanych prób autoryzacji
    IsBlocked BIT NOT NULL DEFAULT 0,        -- Status blokady karty (0 - nie, 1 - tak)
    Balance DECIMAL(18,2) NOT NULL           -- Saldo konta powiązanego z kartą
);
GO

-- Tabela Transactions – przechowuje historię transakcji wypłat
CREATE TABLE Transactions (
    TransactionId INT IDENTITY(1,1) PRIMARY KEY,  -- Identyfikator transakcji
    CardNumber VARCHAR(20) NOT NULL,              -- Numer karty (można opcjonalnie ustawić klucz obcy)
    Amount DECIMAL(18,2) NOT NULL,                -- Kwota transakcji
    Date DATETIME NOT NULL DEFAULT GETDATE()      -- Data i godzina transakcji
);
GO

-- (Opcjonalnie) Dodanie klucza obcego między Transactions a PaymentCards
ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_PaymentCards
FOREIGN KEY (CardNumber)
REFERENCES PaymentCards(CardNumber);
GO

-- Tabela ATMSettings – przechowuje ustawienia bankomatu oraz konfigurację administratora
CREATE TABLE ATMSettings (
    SettingKey VARCHAR(100) PRIMARY KEY,   -- Klucz ustawienia (np. 'AdminPassword', 'AcceptedCardTypes', 'Note_10', itp.)
    SettingValue VARCHAR(100) NOT NULL       -- Wartość ustawienia
);
GO

--------------------------------------------------
-- 3. Wstawianie danych inicjalizacyjnych
--------------------------------------------------

-- Ustawienia bankomatu (w tym hasło administratora, akceptowane typy kart oraz stan gotówki)
INSERT INTO ATMSettings (SettingKey, SettingValue) VALUES 
    ('AdminPassword', 'admin123'),  -- Hasło administratora
    ('AcceptedCardTypes', 'Visa,AmericanExpress,VisaElectron,Mastercard'),  -- Akceptowane rodzaje kart
    ('Note_10', '10'),              -- Liczba banknotów o nominale 10 PLN
    ('Note_20', '10'),              -- Liczba banknotów o nominale 20 PLN
    ('Note_50', '10'),              -- Liczba banknotów o nominale 50 PLN
    ('Note_100', '10'),             -- Liczba banknotów o nominale 100 PLN
    ('Note_200', '10'),             -- Liczba banknotów o nominale 200 PLN
    ('Note_500', '10');             -- Liczba banknotów o nominale 500 PLN
GO

-- Przykładowe dane kart płatniczych
INSERT INTO PaymentCards (CardNumber, PIN, PaymentSystem, FailedAttempts, IsBlocked, Balance)
VALUES 
    ('1111-2222-3333-4444', '1234', 'Visa', 0, 0, 1000.00),
    ('5555-6666-7777-8888', '5678', 'AmericanExpress', 0, 0, 500.00),
    ('9999-8888-7777-6666', '0000', 'VisaElectron', 0, 0, 750.00),
    ('2222-3333-4444-5555', '4321', 'Mastercard', 0, 0, 1200.00);
GO

-- (Opcjonalnie) Wstawienie przykładowych transakcji – można pominąć, gdyż historia będzie budowana podczas użytkowania bankomatu.
INSERT INTO Transactions (CardNumber, Amount, Date)
VALUES 
    ('1111-2222-3333-4444', 200.00, GETDATE()),
    ('5555-6666-7777-8888', 100.00, GETDATE());
GO
