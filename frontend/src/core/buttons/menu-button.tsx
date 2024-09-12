import { LucideMenu } from "lucide-react";
import { Button } from "../shadcn/button";

/**
 * The button component can either be with a outline or background, not both.
 * If so it will default to using the background rather than an outline.
 */
interface MenuButtonProps {
  onClick?: () => void;
  background?: boolean;
  outline?: boolean;
  variant: string;
}

const MenuButton = (props: MenuButtonProps) => {
  switch (props.variant) {
    case "primary":
      return (
        <Button
          onClick={props.onClick}
          size="icon"
          className="p-0 bg-mblue-300 hover:bg-mblue-300 active:bg-mblue-300 border-none hover:border-none active:border-none outline-none hover:outline-none active:outline-none shadow-none focus:bg-mblue-300 focus:outline-none focus:border-none"
        >
          <LucideMenu className="text-mneutral-100" />
        </Button>
      );
    case "white":
      return (
        <Button
          onClick={props.onClick}
          size="icon"
          className="p-0 bg-mneutral-100 hover:bg-mneutral-100 active:bg-mneutral-100 border-none hover:border-none active:border-none outline-none hover:outline-none active:outline-none shadow-none focus:outline-none focus:border-none"
        >
          <LucideMenu className="text-mblue-300" />
        </Button>
      );
  }
};

export default MenuButton;
