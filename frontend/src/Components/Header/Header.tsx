import NavigationList from "./NavigationList/NavigationList";
import "./Header.css";

function Header() {
  return (
    <div className="header">
      <h1>Fullstack Test</h1>
      <p>
        Welcome to the Fullstack Test! We are using data from{" "}
        <a
          href="https://jsonplaceholder.typicode.com"
          target="_blank"
        >
          jsonplaceholder
        </a>.
      </p>
      <NavigationList />
    </div>
  );
};


export default Header;
