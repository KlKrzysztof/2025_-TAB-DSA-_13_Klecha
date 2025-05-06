"# 2025_-TAB-DSA-_13_Klecha" 
# Przygotowanie bazy danych
- Pobierz i zainstaluj [MariaDB Server](https://mariadb.org/)
- Pobierz i zainstaluj [DBeaver](https://dbeaver.io/)
- Pobierz i rozpakuj [WholeDb.zip](https://cdn.discordapp.com/attachments/1355208951578235010/1368672755616190474/WholeDb.zip?ex=681b0d95&is=6819bc15&hm=f686b96124ff6b8bb216cde375f5a9e577e514cd8b48e426f06ecf79d9a3390a&)
  - (DBeaver) Dodaj nowe połączenie
    
    ![Zrzut ekranu 2025-05-06 195249](https://github.com/user-attachments/assets/99b1be2c-15e2-452d-88e6-325675824b97)
    
  - (DBeaver) Wprowadź hasło "root"
  
    ![Zrzut ekranu 2025-05-06 195344](https://github.com/user-attachments/assets/46ba76fd-1d00-4a59-a587-8505eb6a850b)
    
  - (DBeaver) Utwórz nową bazę danych o nazwie fleetmanager
    
    ![Zrzut ekranu 2025-05-06 195459](https://github.com/user-attachments/assets/764ce8d0-7c5b-4228-9c9f-229c1bf69f75)
    ![Zrzut ekranu 2025-05-06 195536](https://github.com/user-attachments/assets/f49df5e6-3d19-470f-879a-37769f35bee7)


  - (DBeaver) Wybierz utworzoną bazę i uruchom skrypt sql z rozpakowanego archiwum WholeDb.zip
    ![Zrzut ekranu 2025-05-06 195645](https://github.com/user-attachments/assets/d318eecd-c279-401b-87ea-b5f78f0bfa90)
    ![image](https://github.com/user-attachments/assets/227688bb-90a4-4e06-ae95-63d210e0f61b)

- Upwenij się że nazwa bazy danych i hasło w pliku [appsettings.json](https://github.com/KlKrzysztof/2025_-TAB-DSA-_13_Klecha/blob/main/FleetManager/FleetManager.Server/appsettings.json) są zgodne z konfiguracją

  ![image](https://github.com/user-attachments/assets/c8a383c7-020c-465a-a118-283f412a4835)

# Instalacja bibliotek
- Otwórz konsolę w visual studio i wykonaj poniższe polecenia
- npm install react-router react-router-dom
- npm install @types/react @types/react-dom --save-dev
