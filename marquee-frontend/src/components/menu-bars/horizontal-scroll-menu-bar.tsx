import { Button } from "../ui/button";
import { ScrollArea, ScrollBar } from "@/components/ui/scroll-area";

export interface HorizontalScrollMenuItem {
  title: string;
  link: string;
}

interface HorizontalScrollMenuBarProps {
  links: HorizontalScrollMenuItem[];
  onMenuItemClick: (link: string) => void; // Add this prop
}

export function HorizontalScrollMenuBar({
  links,
  onMenuItemClick,
}: HorizontalScrollMenuBarProps) {
  return (
    <ScrollArea className="w-96 whitespace-nowrap rounded-md border">
      <div className="flex w-max space-x-4 p-4">
        {links.map((link) => (
          <Button
            key={link.title}
            onClick={() => onMenuItemClick(link.link)} // Call the click handler with the link
          >
            {link.title}
          </Button>
        ))}
      </div>
      <ScrollBar orientation="horizontal" />
    </ScrollArea>
  );
}
