import { LucideMenu, LucideUserPlus } from "lucide-react";
import { Button } from "../button";

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
      if (props.background) {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-marquee_blue-500"
          >
            <LucideMenu color="#F9FBFD" />
          </Button>
        );
      } else if (props.outline) {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-transparent outline outline-2 outline-marquee_blue-500"
          >
            <LucideMenu color="#004D9B" />
          </Button>
        );
      } else {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-transparent focus:bg-transparent active:bg-transparent"
          >
            <LucideMenu color="#004D9B" />
          </Button>
        );
      }
    case "white":
      if (props.background) {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-transparent"
          >
            <LucideMenu color="#F9FBFD" />
          </Button>
        );
      } else if (props.outline) {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-transparent outline outline-2 outline-marquee_neutral-100"
          >
            <LucideMenu color="#F9FBFD" />
          </Button>
        );
      } else {
        return (
          <Button
            onClick={props.onClick}
            size="icon"
            className="bg-transparent"
          >
            <LucideMenu color="#F9FBFD" />
          </Button>
        );
      }
  }
};

export default MenuButton;
