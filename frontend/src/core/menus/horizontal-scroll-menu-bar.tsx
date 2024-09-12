import { Button } from "../shadcn/button";
import { ScrollArea, ScrollBar } from "../shadcn/scroll-area";

export interface HorizontalScrollMenuItem {
  title: string;
  link: string;
}

interface HorizontalScrollMenuBarProps {
  links: HorizontalScrollMenuItem[];
  onMenuItemClick: (link: string) => void;
}

export function HorizontalScrollMenuBar({
  links,
  onMenuItemClick,
}: HorizontalScrollMenuBarProps) {
  return (
    <ScrollArea className="w-96 whitespace-nowrap rounded-md border">
      <div className="flex w-max space-x-2 p-2">
        {links.map((link) => (
          <Button
            className="bg-mblue-500 text-mneutral-100 hover:bg-mblue-300 active:bg-mblue-300 focus:bg-mblue-300"
            key={link.title}
            onClick={() => onMenuItemClick(link.link)}
          >
            {link.title}
          </Button>
        ))}
      </div>
      <ScrollBar orientation="horizontal" />
    </ScrollArea>
  );
}
