import { LucideUserPlus } from "lucide-react";
import { Button, buttonVariants } from "../shadcn/button";

/**
 * The button component can either be with a outline or background, not both.
 * If so it will default to using the background rather than an outline.
 */
interface AddUserButtonProps {
  onClick?: () => void;
  background?: boolean;
  outline?: boolean;
  variant: "primary" | "secondary" | "detail" | "warning" | "verification";
}

const AddUserButton = (props: AddUserButtonProps) => {
  switch (props.variant) {
    case "primary":
      if (props.background) {
        return (
          <Button className={buttonVariants({ variant: "outline" })}>
            <LucideUserPlus color="#F9FBFD" />
          </Button>
        );
      } else if (props.outline) {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-transparent outline outline-2 outline-marquee_blue-500"
          >
            <LucideUserPlus color="#004D9B" />
          </Button>
        );
      } else {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-transparent"
          >
            <LucideUserPlus color="#004D9B" />
          </Button>
        );
      }
  }
};

export default AddUserButton;
