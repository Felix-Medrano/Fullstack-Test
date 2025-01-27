import React, { useEffect } from 'react';

const InfiniteScroll: React.FC<T> = ({ loadMore, isLoading, children }) => {
  const handleScroll = () => {
    if (window.innerHeight + document.documentElement.scrollTop !== document.documentElement.offsetHeight || isLoading) return;
    loadMore();
  };

  useEffect(() => {
    window.addEventListener('scroll', handleScroll);
    return () => window.removeEventListener('scroll', handleScroll);
  }, [isLoading]);

  return <>{children}</>;
};

export default InfiniteScroll;