import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import Article from "./components/Article/Article"; 

const AppRoutes = [
  {
    index: true,
    element: <Home/>
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  {
    path: "/fetch-article",
    element: <Article articleId="xxxx"/>
  }
];

export default AppRoutes;
