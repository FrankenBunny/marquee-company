import { LucideLoaderCircle } from "lucide-react";

interface LoadingSpinnerProps {
  size: number;
}

const LoadingSpinner: React.FC<LoadingSpinnerProps> = ({ size }) => {
  return (
    <div className="flex items-center justify-center">
      <LucideLoaderCircle
        className="animate-spin text-marquee_blue-500"
        size={size}
      />
    </div>
  );
};

export default LoadingSpinner;
