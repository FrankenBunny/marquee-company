import { LucideLock, LucideUser } from "lucide-react";

const SidebarMenu = () => {
  return (
    <>
      <div className="bg-marquee_blue-500">
        <ul className="">
          <a href="" className="">
            <li className="px-5 py-3 flex flex-col items-center text-marquee_neutral-100 hover:bg-marquee_blue-300">
              <LucideUser />
              <h2 className="mt-1">Användare</h2>
            </li>
          </a>
          <a href="" className="">
            <li className="px-5 py-3 flex flex-col items-center text-marquee_neutral-100 hover:bg-marquee_blue-300">
              <LucideLock />
              <h2 className="mt-1">Roller</h2>
            </li>
          </a>
        </ul>
      </div>
    </>
  );
};

export default SidebarMenu;
