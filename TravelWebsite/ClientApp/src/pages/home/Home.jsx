import { useEffect, useState } from "react";
import PropertyApiService from "../../adapters/xhr/PropertyApiService";
import Featured from "../../components/featured/Featured";
import FeaturedProperties from "../../components/featuredProperties/FeaturedProperties";
import Footer from "../../components/footer/Footer";
import Header from "../../components/header/Header";
import MailList from "../../components/mailList/MailList";
import Navbar from "../../components/navbar/Navbar";
import PropertyList from "../../components/propertyList/PropertyList";
import "./home.css";

const Home = () => {
  const [featuredItems, setFeaturedItems] = useState([]);
  const [itemsByType, setItemsByType] = useState([]);

  const fetchFeaturedItems = async () => {
    let result = await PropertyApiService.getByCity();
    if (result) setFeaturedItems(result);
  };

  const fetchItemsByType = async () => {
    let result = await PropertyApiService.getByType();
    if (result) setItemsByType(result);
  };

  useEffect(() => {
    fetchFeaturedItems();
    fetchItemsByType();
  }, []);
  return (
    <div>
      <Navbar />
      <Header />
      <div className="homeContainer">
        <Featured items={featuredItems} />
        <h1 className="homeTitle">Browse by property type</h1>
        <PropertyList items={itemsByType} />
        <h1 className="homeTitle">Homes guests love</h1>
        <FeaturedProperties />
        <MailList />
        <Footer />
      </div>
    </div>
  );
};

export default Home;
