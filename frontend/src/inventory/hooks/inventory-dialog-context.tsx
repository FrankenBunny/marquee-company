import { createContext, useContext, useState, ReactNode } from "react";

interface InventoryDialogContextType {
  isInventoryDialogOpen: boolean;
  inventoryDialogType: "category" | "rentable" | "part" | "tag" | "item";
  inventoryDialogId: string;
  openDialog: (
    type: "category" | "rentable" | "part" | "tag" | "item",
    id: string
  ) => void;
  closeDialog: () => void;
}

const defaultInventoryDialogContextValue: InventoryDialogContextType = {
  isInventoryDialogOpen: false,
  inventoryDialogType: "rentable",
  inventoryDialogId: "",
  openDialog: () => {},
  closeDialog: () => {},
};

const InventoryDialogContext = createContext<InventoryDialogContextType>(
  defaultInventoryDialogContextValue
);

export const useInventoryDialog = () => useContext(InventoryDialogContext);

interface InventoryDialogProviderProps {
  children: ReactNode;
}

export const InventoryDialogProvider = ({
  children,
}: InventoryDialogProviderProps) => {
  const [isInventoryDialogOpen, setIsInventoryDialogOpen] = useState(false);
  const [inventoryDialogType, setInventoryDialogType] = useState<
    "category" | "rentable" | "part" | "tag" | "item"
  >("rentable");
  const [inventoryDialogId, setInventoryDialogId] = useState<string>("");

  const openDialog = (
    type: "category" | "rentable" | "part" | "tag" | "item",
    id: string
  ) => {
    setInventoryDialogType(type);
    setInventoryDialogId(id);
    setIsInventoryDialogOpen(true);
  };

  const closeDialog = () => {
    setIsInventoryDialogOpen(false);
    setInventoryDialogType("rentable");
    setInventoryDialogId("");
  };

  return (
    <InventoryDialogContext.Provider
      value={{
        isInventoryDialogOpen,
        inventoryDialogType,
        inventoryDialogId,
        openDialog,
        closeDialog,
      }}
    >
      {children}
    </InventoryDialogContext.Provider>
  );
};
