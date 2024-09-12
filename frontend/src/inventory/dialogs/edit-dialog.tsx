import { Dialog, DialogContent } from "../../core/shadcn/dialog";
import { DialogTitle } from "@radix-ui/react-dialog";
import { useInventoryDialog } from "@/inventory/hooks/inventory-dialog-context";
import CategoryEdit from "@/inventory/category/CategoryEdit";

const EditDialog = () => {
  const { isInventoryDialogOpen, closeDialog } = useInventoryDialog();
  const { inventoryDialogType, inventoryDialogId } = useInventoryDialog();

  if (!isInventoryDialogOpen) return null;

  return (
    <Dialog open={isInventoryDialogOpen} onOpenChange={closeDialog}>
      <DialogTitle>Edit</DialogTitle>
      <DialogContent className="my-0 py-0 min-h-[25rem] rounded-md w-10/12 bg-mneutral-100 p-0">
        {inventoryDialogType == "category" && (
          <CategoryEdit categoryId={inventoryDialogId} />
        )}
        {/* Else call edit for other type && */}
      </DialogContent>
    </Dialog>
  );
};

export default EditDialog;
