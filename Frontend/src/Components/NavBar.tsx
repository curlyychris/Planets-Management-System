
const NavBar = ({ onLogout }: { onLogout: () => void }) => {
  return (
    <nav className="bg-gray-800 p-4 w-full">
      <div className="container mx-auto flex justify-between items-center">
        <div className="text-white text-lg font-bold">Planets Assignment Christy Karam</div>
        <button
          onClick={onLogout}
          className="bg-red-500 text-white px-4 py-2 rounded-lg hover:bg-red-600 focus:outline-none focus:ring-2 focus:ring-red-300"
        >
          Logout
        </button>
      </div>
    </nav>
  );
};

export default NavBar;