// Mock data for the auction system
const mockData = {
  // Users data
  users: [
    {
      id: 1,
      name: "John Doe",
      email: "john@example.com",
      role: "buyer",
      joinedDate: "2023-01-15",
      status: "active",
      profileImage: "https://via.placeholder.com/150",
    },
    {
      id: 2,
      name: "Jane Smith",
      email: "jane@example.com",
      role: "seller",
      joinedDate: "2023-02-20",
      status: "active",
      profileImage: "https://via.placeholder.com/150",
    },
    {
      id: 3,
      name: "Robert Johnson",
      email: "robert@example.com",
      role: "buyer",
      joinedDate: "2023-03-05",
      status: "blocked",
      profileImage: "https://via.placeholder.com/150",
    },
    {
      id: 4,
      name: "Emily Davis",
      email: "emily@example.com",
      role: "seller",
      joinedDate: "2023-03-10",
      status: "active",
      profileImage: "https://via.placeholder.com/150",
    },
    {
      id: 5,
      name: "Michael Wilson",
      email: "michael@example.com",
      role: "buyer",
      joinedDate: "2023-04-01",
      status: "active",
      profileImage: "https://via.placeholder.com/150",
    },
  ],

  // Books data
  books: [
    {
      id: 1,
      title: "The Great Gatsby",
      subcategory: "fiction",
      description: "A classic novel by F. Scott Fitzgerald set in the Jazz Age.",
      startingPrice: 25.99,
      currentBid: 35.5,
      bids: 4,
      status: "active",
      image: "https://via.placeholder.com/200x300?text=The+Great+Gatsby",
    },
    {
      id: 2,
      title: "To Kill a Mockingbird",
      subcategory: "fiction",
      description: "Harper Lee's Pulitzer Prize-winning novel about racial injustice.",
      startingPrice: 30.0,
      currentBid: 42.75,
      bids: 6,
      status: "active",
      image: "https://via.placeholder.com/200x300?text=To+Kill+a+Mockingbird",
    },
    {
      id: 3,
      title: "Sapiens: A Brief History of Humankind",
      subcategory: "non-fiction",
      description: "A book by Yuval Noah Harari that explores the history of humanity.",
      startingPrice: 35.5,
      currentBid: 35.5,
      bids: 0,
      status: "active",
      image: "https://via.placeholder.com/200x300?text=Sapiens",
    },
    {
      id: 4,
      title: "The Bible",
      subcategory: "religion",
      description: "A rare antique Bible with gold-leaf pages and leather binding.",
      startingPrice: 150.0,
      currentBid: 225.0,
      bids: 8,
      status: "active",
      image: "https://via.placeholder.com/200x300?text=Antique+Bible",
    },
    {
      id: 5,
      title: "Rich Dad Poor Dad",
      subcategory: "business",
      description: "Personal finance book by Robert Kiyosaki.",
      startingPrice: 20.0,
      currentBid: 20.0,
      bids: 0,
      status: "inactive",
      image: "https://via.placeholder.com/200x300?text=Rich+Dad+Poor+Dad",
    },
  ],

  // Furniture data
  furniture: [
    {
      id: 1,
      title: "Vintage Leather Sofa",
      subcategory: "sofas",
      description: "A beautiful vintage leather sofa in excellent condition.",
      startingPrice: 499.99,
      currentBid: 550.0,
      bids: 3,
      status: "active",
      image: "https://via.placeholder.com/300x200?text=Vintage+Leather+Sofa",
    },
    {
      id: 2,
      title: "Solid Oak Dining Table",
      subcategory: "tables",
      description: "Handcrafted solid oak dining table that seats 6 people.",
      startingPrice: 650.0,
      currentBid: 725.5,
      bids: 5,
      status: "active",
      image: "https://via.placeholder.com/300x200?text=Oak+Dining+Table",
    },
    {
      id: 3,
      title: "Queen Size Bed Frame",
      subcategory: "bedroom",
      description: "Modern queen size bed frame with headboard.",
      startingPrice: 350.0,
      currentBid: 350.0,
      bids: 0,
      status: "active",
      image: "https://via.placeholder.com/300x200?text=Queen+Bed+Frame",
    },
    {
      id: 4,
      title: "Antique Bookshelf",
      subcategory: "storage",
      description: "Victorian-era bookshelf with intricate carvings.",
      startingPrice: 400.0,
      currentBid: 475.0,
      bids: 4,
      status: "active",
      image: "https://via.placeholder.com/300x200?text=Antique+Bookshelf",
    },
    {
      id: 5,
      title: "Decorative Wall Mirror",
      subcategory: "decor",
      description: "Large decorative wall mirror with gold frame.",
      startingPrice: 150.0,
      currentBid: 150.0,
      bids: 0,
      status: "inactive",
      image: "https://via.placeholder.com/300x200?text=Wall+Mirror",
    },
  ],

  // Electronics data
  electronics: [
    {
      id: 1,
      title: "iPhone 13 Pro",
      subcategory: "smartphones",
      description: "Apple iPhone 13 Pro, 256GB, Sierra Blue, excellent condition.",
      startingPrice: 699.99,
      currentBid: 750.0,
      bids: 6,
      status: "active",
      brand: "Apple",
      condition: "like-new",
      image: "https://via.placeholder.com/300x300?text=iPhone+13+Pro",
    },
    {
      id: 2,
      title: "MacBook Pro 16-inch",
      subcategory: "laptops",
      description: "2021 MacBook Pro with M1 Pro chip, 16GB RAM, 512GB SSD.",
      startingPrice: 1500.0,
      currentBid: 1650.0,
      bids: 4,
      status: "active",
      brand: "Apple",
      condition: "like-new",
      image: "https://via.placeholder.com/300x300?text=MacBook+Pro",
    },
    {
      id: 3,
      title: "Samsung Galaxy Tab S7",
      subcategory: "tablets",
      description: "Samsung Galaxy Tab S7, 128GB, with S Pen included.",
      startingPrice: 450.0,
      currentBid: 450.0,
      bids: 0,
      status: "active",
      brand: "Samsung",
      condition: "good",
      image: "https://via.placeholder.com/300x300?text=Galaxy+Tab+S7",
    },
    {
      id: 4,
      title: "Sony Alpha A7 III",
      subcategory: "cameras",
      description: "Sony Alpha A7 III Mirrorless Camera with 28-70mm lens.",
      startingPrice: 1200.0,
      currentBid: 1350.0,
      bids: 5,
      status: "active",
      brand: "Sony",
      condition: "good",
      image: "https://via.placeholder.com/300x300?text=Sony+A7+III",
    },
    {
      id: 5,
      title: "PlayStation 5",
      subcategory: "gaming",
      description: "Sony PlayStation 5 Disc Edition, barely used, with 2 controllers.",
      startingPrice: 500.0,
      currentBid: 575.0,
      bids: 8,
      status: "active",
      brand: "Sony",
      condition: "like-new",
      image: "https://via.placeholder.com/300x300?text=PlayStation+5",
    },
  ],

  // Notifications data
  notifications: [
    {
      id: 1,
      title: "New User Registration",
      content: "Michael Wilson has registered as a new buyer.",
      type: "user",
      time: "2023-04-01T10:30:00",
      status: "unread",
    },
    {
      id: 2,
      title: "New Auction Created",
      content: "Jane Smith has created a new auction for 'Vintage Leather Sofa'.",
      type: "auction",
      time: "2023-03-30T14:45:00",
      status: "read",
    },
    {
      id: 3,
      title: "Bid Placed",
      content: "John Doe has placed a bid of $750.00 on 'iPhone 13 Pro'.",
      type: "bid",
      time: "2023-03-29T09:15:00",
      status: "read",
    },
    {
      id: 4,
      title: "Auction Ended",
      content: "The auction for 'To Kill a Mockingbird' has ended. Winning bid: $42.75",
      type: "auction",
      time: "2023-03-28T16:20:00",
      status: "read",
    },
    {
      id: 5,
      title: "System Maintenance",
      content: "The system will be down for maintenance on April 5th from 2:00 AM to 4:00 AM.",
      type: "system",
      time: "2023-03-27T11:00:00",
      status: "read",
    },
  ],

  // Dashboard stats
  dashboardStats: {
    totalUsers: 125,
    userGrowth: 15,
    activeAuctions: 42,
    auctionGrowth: 8,
    totalBids: 287,
    bidGrowth: 12,
    newNotifications: 3,
    notificationGrowth: 5,
  },

  // Chart data
  chartData: {
    auctionActivity: {
      labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun"],
      datasets: [
        {
          label: "New Auctions",
          data: [12, 19, 15, 20, 25, 16],
        },
        {
          label: "Bids Placed",
          data: [50, 65, 60, 45, 70, 55],
        },
      ],
    },
    categoryDistribution: {
      labels: ["Books", "Furniture", "Electronics"],
      data: [35, 25, 40],
    },
  },
}

// Function to save data to localStorage
function saveData() {
  localStorage.setItem("auctionSystemData", JSON.stringify(mockData))
}

// Function to load data from localStorage
function loadData() {
  const storedData = localStorage.getItem("auctionSystemData")
  if (storedData) {
    return JSON.parse(storedData)
  }
  // If no data in localStorage, save the mock data and return it
  saveData()
  return mockData
}

// Initialize data if not already in localStorage
if (!localStorage.getItem("auctionSystemData")) {
  saveData()
}
