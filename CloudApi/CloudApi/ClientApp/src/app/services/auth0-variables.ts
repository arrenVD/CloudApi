interface AuthConfig {
  clientID: string;
  domain: string;
  callbackURL: string;
  apiUrl: string;
}

export const AUTH_CONFIG: AuthConfig = {
  clientID: 'Eu5izVtJVvpoaCqxLxoBEF1rxI6ZQ37E',
  domain: 'dev-d0xsb9au.eu.auth0.com',
  callbackURL: 'https://localhost:5001/callback',
  apiUrl: 'https://localhost:5001/api/v1'
};
