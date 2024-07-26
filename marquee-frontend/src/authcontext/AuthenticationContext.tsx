/* eslint-disable  @typescript-eslint/no-explicit-any */
/**
 * Authentication context.
 * Manages user authentication state and provides
 * authentication methods to related components.
 *
 */

import React, { createContext, useContext, useState, ReactNode } from "react";

interface AuthenticationContext {
  children: ReactNode;
}

interface AuthenticationProviderProperties {
  children: ReactNode;
}

interface AuthenticationUser {
  id: string;
  username: string;
}

const AuthenticationContext = createContext<{
  user: AuthenticationUser | null;
  login: (userData: any) => void;
  logout: () => void;
} | null>(null);

export const AuthenticationProvider: React.FC<
  AuthenticationProviderProperties
> = ({ children }) => {
  const [user, setUser] = useState<any>(null);

  const login = (userData: AuthenticationUser) => {
    // Add login logic
    setUser(userData);
  };

  const logout = () => {
    // Implement logout logic here
    setUser(null);
  };

  return (
    <AuthenticationContext.Provider value={{ user, login, logout }}>
      {children}
    </AuthenticationContext.Provider>
  );
};

export const useAuthentication = () => {
  const context = useContext(AuthenticationContext);
  if (context == null)
    throw new Error("useAuthentication must be used within a Provider");

  return context;
};
