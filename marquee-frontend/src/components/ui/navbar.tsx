import MenuButton from "./buttons/menu-button";
import { useRef, useState, useEffect } from "react";

type Callback = () => void;

const useOutsideClick = (
  refs: React.RefObject<HTMLElement>[],
  callback: Callback
) => {
  useEffect(() => {
    const handleClick = (event: MouseEvent) => {
      if (
        refs.every(
          (ref) => ref.current && !ref.current.contains(event.target as Node)
        )
      ) {
        callback();
      }
    };

    document.addEventListener("mousedown", handleClick);

    return () => {
      document.removeEventListener("mousedown", handleClick);
    };
  }, [refs, callback]);
};

const NavigationBar = () => {
  const [menuOpen, setMenuOpen] = useState(false);

  const buttonRef = useRef<HTMLDivElement>(null);
  const menuRef = useRef<HTMLDivElement>(null);

  useOutsideClick([buttonRef, menuRef], () => {
    setMenuOpen(false);
  });

  const handleClick = () => {
    setMenuOpen((prevState) => !prevState);
  };

  return (
    <div className="fixed t-0 r-0 z-999 w-screen">
      <div
        className={
          menuOpen
            ? "bg-marquee_neutral-100 w-1/2 h-screen md:w-1/4 lg:w-1/6"
            : ""
        }
      >
        <div ref={buttonRef} className="h-10">
          <MenuButton
            variant={menuOpen ? "primary" : "white"}
            background={false}
            onClick={handleClick}
          />
        </div>
        {menuOpen && (
          <div className="bg-marquee_neutral-100 absolute" ref={menuRef}>
            <ul className="flex flex-col items-start gap-4 bg-marquee_neutral-100 text-2xl">
              <a href="inventory" className="">
                <li className="px-5 py-3 flex flex-col items-center bg-marquee_neutral-100 text-marquee_blue-500 hover:text-marquee_blue-300">
                  <h2 className="mt-1">Inventering</h2>
                </li>
              </a>
              <a href="users" className="">
                <li className="px-5 py-3 flex flex-col items-center bg-marquee_neutral-100 text-marquee_blue-500 hover:text-marquee_blue-300">
                  <h2 className="mt-1">Hantera</h2>
                </li>
              </a>
            </ul>
          </div>
        )}
      </div>
    </div>
  );
};

export default NavigationBar;
