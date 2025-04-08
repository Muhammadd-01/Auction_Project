// Ratings page JavaScript

document.addEventListener("DOMContentLoaded", () => {
  // Initialize variables and mock data
  const reviewsData = [
    {
      id: 1,
      userName: "John Doe",
      userImage: "https://via.placeholder.com/50",
      rating: 5,
      date: new Date(Date.now() - 2 * 24 * 60 * 60 * 1000),
      content:
        "The iPhone 13 Pro exceeded my expectations! The camera quality is outstanding, and the battery life is much better than my previous phone. Delivery was prompt and the item was exactly as described.",
      category: "Electronics",
      product: "iPhone 13 Pro",
      status: "published",
      flagged: false,
    },
    {
      id: 2,
      userName: "Jane Smith",
      userImage: "https://via.placeholder.com/50",
      rating: 2,
      date: new Date(Date.now() - 7 * 24 * 60 * 60 * 1000),
      content:
        "I'm disappointed with the Vintage Leather Sofa. The color is different from what was shown in the pictures, and the quality doesn't match the price. The delivery was also delayed by several days.",
      category: "Furniture",
      product: "Vintage Leather Sofa",
      status: "published",
      flagged: false,
    },
    {
      id: 3,
      userName: "Robert Johnson",
      userImage: "https://via.placeholder.com/50",
      rating: 4.5,
      date: new Date(Date.now() - 14 * 24 * 60 * 60 * 1000),
      content:
        "The Great Gatsby first edition is a treasure! The book is in excellent condition considering its age. The seller was very knowledgeable and provided additional information about its history. Highly recommend!",
      category: "Books",
      product: "The Great Gatsby",
      status: "published",
      flagged: false,
    },
    {
      id: 4,
      userName: "Emily Davis",
      userImage: "https://via.placeholder.com/50",
      rating: 3,
      date: new Date(Date.now() - 10 * 24 * 60 * 60 * 1000),
      content:
        "The PlayStation 5 works well but had minor scratches that weren't mentioned in the description. Shipping was fast though.",
      category: "Electronics",
      product: "PlayStation 5",
      status: "published",
      flagged: false,
    },
    {
      id: 5,
      userName: "Michael Wilson",
      userImage: "https://via.placeholder.com/50",
      rating: 1,
      date: new Date(Date.now() - 5 * 24 * 60 * 60 * 1000),
      content: "Terrible experience. The Oak Dining Table arrived damaged and the seller was not responsive. Avoid!",
      category: "Furniture",
      product: "Oak Dining Table",
      status: "published",
      flagged: true,
    },
  ]

  // Display all reviews initially
  displayReviews(reviewsData)

  // Mock loadData and showToast functions, and ensure bootstrap is available
  const loadData = () => {
    console.warn("loadData() function is not implemented. Returning empty object.")
    return {}
  }

  const showToast = (message, type) => {
    console.log(`Toast: ${message} (Type: ${type})`)
    // You might want to use a library like Bootstrap's toast component here
  }

  // Check if Bootstrap is available
  if (typeof bootstrap === "undefined") {
    console.warn("Bootstrap is not properly loaded. Some features might not work as expected.")
    // Mock bootstrap object to prevent errors
    window.bootstrap = {
      Modal: {
        getInstance: (element) => {
          return {
            hide: () => {
              console.log("Modal hide() called (mocked)")
            },
          }
        },
      },
    }
  }

  // Initialize data
  const data = loadData()

  // Show custom date range when "Custom Range" is selected
  const dateRangeFilter = document.getElementById("dateRangeFilter")
  const customDateRange = document.getElementById("customDateRange")

  if (dateRangeFilter) {
    dateRangeFilter.addEventListener("change", function () {
      if (this.value === "custom") {
        customDateRange.classList.remove("d-none")
      } else {
        customDateRange.classList.add("d-none")
      }
    })
  }

  // Toggle between all reviews and flagged reviews
  const allReviewsBtn = document.getElementById("allReviewsBtn")
  const flaggedReviewsBtn = document.getElementById("flaggedReviewsBtn")

  if (allReviewsBtn && flaggedReviewsBtn) {
    allReviewsBtn.addEventListener("click", () => {
      allReviewsBtn.classList.add("active")
      flaggedReviewsBtn.classList.remove("active")
      // Load all reviews
      displayReviews(reviewsData)
    })

    flaggedReviewsBtn.addEventListener("click", () => {
      flaggedReviewsBtn.classList.add("active")
      allReviewsBtn.classList.remove("active")
      // Load flagged reviews
      const flaggedReviews = reviewsData.filter((review) => review.flagged)
      displayReviews(flaggedReviews)
    })
  }

  // Apply filters button
  const applyFiltersBtn = document.getElementById("applyFiltersBtn")

  if (applyFiltersBtn) {
    applyFiltersBtn.addEventListener("click", () => {
      // Get filter values
      const dateRange = document.getElementById("dateRangeFilter").value
      const product = document.getElementById("productFilter").value
      const seller = document.getElementById("sellerFilter").value

      // Apply date filters
      let filteredReviews = [...reviewsData]

      // Apply date range filter
      if (dateRange !== "all") {
        const now = new Date()

        switch (dateRange) {
          case "today":
            const today = new Date(now.getFullYear(), now.getMonth(), now.getDate())
            filteredReviews = filteredReviews.filter((review) => review.date >= today)
            break
          case "week":
            const oneWeekAgo = new Date(now - 7 * 24 * 60 * 60 * 1000)
            filteredReviews = filteredReviews.filter((review) => review.date >= oneWeekAgo)
            break
          case "month":
            const oneMonthAgo = new Date(now.getFullYear(), now.getMonth() - 1, now.getDate())
            filteredReviews = filteredReviews.filter((review) => review.date >= oneMonthAgo)
            break
          case "year":
            const oneYearAgo = new Date(now.getFullYear() - 1, now.getMonth(), now.getDate())
            filteredReviews = filteredReviews.filter((review) => review.date >= oneYearAgo)
            break
          case "custom":
            const startDate = new Date(document.getElementById("startDate").value)
            const endDate = new Date(document.getElementById("endDate").value)
            endDate.setHours(23, 59, 59, 999) // Include the entire end day

            if (!isNaN(startDate.getTime()) && !isNaN(endDate.getTime())) {
              filteredReviews = filteredReviews.filter((review) => review.date >= startDate && review.date <= endDate)
            }
            break
        }
      }

      // Apply product filter
      if (product !== "all") {
        filteredReviews = filteredReviews.filter((review) => {
          // Map product values to product names
          switch (product) {
            case "iphone":
              return review.product === "iPhone 13 Pro"
            case "macbook":
              return review.product === "MacBook Pro"
            case "sofa":
              return review.product === "Vintage Leather Sofa"
            case "gatsby":
              return review.product === "The Great Gatsby"
            case "mockingbird":
              return review.product === "To Kill a Mockingbird"
            default:
              return true
          }
        })
      }

      // Apply seller filter (in a real app, you would have seller information)
      if (seller !== "all") {
        // This is just a mock implementation
        // In a real app, you would filter by actual seller data
        filteredReviews = filteredReviews.filter((review) => {
          if (seller === "john" && (review.id === 1 || review.id === 4)) return true
          if (seller === "jane" && review.id === 2) return true
          if (seller === "robert" && (review.id === 3 || review.id === 5)) return true
          return false
        })
      }

      // Apply status filters
      const publishedCheck = document.getElementById("publishedCheck").checked
      const pendingCheck = document.getElementById("pendingCheck").checked
      const flaggedCheck = document.getElementById("flaggedCheck").checked

      if (!publishedCheck || !pendingCheck || flaggedCheck) {
        filteredReviews = filteredReviews.filter((review) => {
          if (review.status === "published" && publishedCheck) return true
          if (review.status === "pending" && pendingCheck) return true
          if (review.flagged && flaggedCheck) return true
          return false
        })
      }

      // Display filtered reviews
      displayReviews(filteredReviews)

      // Close modal
      const filterModal = bootstrap.Modal.getInstance(document.getElementById("filterModal"))
      if (filterModal) filterModal.hide()
    })
  }

  // Reset filters button
  const resetFiltersBtn = document.getElementById("resetFilters")

  if (resetFiltersBtn) {
    resetFiltersBtn.addEventListener("click", () => {
      // Reset all filter inputs
      document.getElementById("reviewSearch").value = ""
      document.getElementById("categoryFilter").value = "all"
      document.getElementById("ratingFilter").value = "all"
      document.getElementById("sortFilter").value = "newest"

      // Display all reviews
      displayReviews(reviewsData)
    })
  }

  // Search functionality
  const reviewSearch = document.getElementById("reviewSearch")
  if (reviewSearch) {
    reviewSearch.addEventListener("input", () => {
      filterAndSortReviews()
    })
  }

  // Category filter
  const categoryFilter = document.getElementById("categoryFilter")
  if (categoryFilter) {
    categoryFilter.addEventListener("change", () => {
      filterAndSortReviews()
    })
  }

  // Rating filter
  const ratingFilter = document.getElementById("ratingFilter")
  if (ratingFilter) {
    ratingFilter.addEventListener("change", () => {
      filterAndSortReviews()
    })
  }

  // Sort filter
  const sortFilter = document.getElementById("sortFilter")
  if (sortFilter) {
    sortFilter.addEventListener("change", () => {
      filterAndSortReviews()
    })
  }

  // Function to filter and sort reviews based on current filter values
  function filterAndSortReviews() {
    const searchTerm = document.getElementById("reviewSearch").value.toLowerCase()
    const category = document.getElementById("categoryFilter").value
    const rating = document.getElementById("ratingFilter").value
    const sortBy = document.getElementById("sortFilter").value

    let filteredReviews = [...reviewsData]

    // Apply search filter
    if (searchTerm) {
      filteredReviews = filteredReviews.filter(
        (review) =>
          review.content.toLowerCase().includes(searchTerm) ||
          review.userName.toLowerCase().includes(searchTerm) ||
          review.product.toLowerCase().includes(searchTerm),
      )
    }

    // Apply category filter
    if (category !== "all") {
      filteredReviews = filteredReviews.filter((review) => review.category.toLowerCase() === category.toLowerCase())
    }

    // Apply rating filter
    if (rating !== "all") {
      const ratingValue = Number.parseInt(rating)
      filteredReviews = filteredReviews.filter((review) => {
        const reviewRating = Math.floor(review.rating)
        return reviewRating === ratingValue
      })
    }

    // Apply sorting
    filteredReviews.sort((a, b) => {
      switch (sortBy) {
        case "newest":
          return b.date - a.date
        case "oldest":
          return a.date - b.date
        case "highest":
          return b.rating - a.rating
        case "lowest":
          return a.rating - b.rating
        default:
          return 0
      }
    })

    // Display filtered and sorted reviews
    displayReviews(filteredReviews)
  }

  // Handle review actions (reply, flag, delete)
  const reviewsList = document.getElementById("reviewsList")

  if (reviewsList) {
    reviewsList.addEventListener("click", (e) => {
      // Check if the clicked element is a button or its child
      const button = e.target.closest("button")

      if (!button) return

      // Get the review item
      const reviewItem = button.closest(".list-group-item")
      const reviewId = Number.parseInt(reviewItem.dataset.id)

      // Handle different actions
      if (button.title === "Reply") {
        // Show reply form or modal
        alert("Reply functionality would open here")
      } else if (button.title === "Flag") {
        // Flag the review
        button.classList.toggle("btn-outline-warning")
        button.classList.toggle("btn-warning")

        // Update the review's flagged status in the data
        const reviewIndex = reviewsData.findIndex((r) => r.id === reviewId)
        if (reviewIndex !== -1) {
          reviewsData[reviewIndex].flagged = !reviewsData[reviewIndex].flagged
        }

        if (button.classList.contains("btn-warning")) {
          alert("Review has been flagged")
        } else {
          alert("Flag has been removed")
        }
      } else if (button.title === "Delete") {
        // Confirm before deleting
        if (confirm("Are you sure you want to delete this review?")) {
          // Add fade-out animation
          reviewItem.style.transition = "opacity 0.5s ease, transform 0.5s ease"
          reviewItem.style.opacity = "0"
          reviewItem.style.transform = "translateX(20px)"

          // Remove the review from the data
          const reviewIndex = reviewsData.findIndex((r) => r.id === reviewId)
          if (reviewIndex !== -1) {
            reviewsData.splice(reviewIndex, 1)
          }

          // Remove after animation completes
          setTimeout(() => {
            reviewItem.remove()
            alert("Review has been deleted")
          }, 500)
        }
      }
    })
  }

  // Function to display reviews
  function displayReviews(reviews) {
    const reviewsList = document.getElementById("reviewsList")
    if (!reviewsList) return

    // Clear the reviews list
    reviewsList.innerHTML = ""

    if (reviews.length === 0) {
      reviewsList.innerHTML = `
        <div class="text-center py-5 text-muted">
          <i class="bi bi-star-slash display-4"></i>
          <p class="mt-3">No reviews found</p>
        </div>
      `
      return
    }

    // Add each review to the list
    reviews.forEach((review, index) => {
      const reviewItem = document.createElement("div")
      reviewItem.className = "list-group-item p-3 border rounded mb-3"
      reviewItem.dataset.id = review.id

      // Format date
      const timeAgo = getTimeAgo(review.date)

      // Generate stars HTML
      const starsHtml = generateStarsHtml(review.rating)

      reviewItem.innerHTML = `
        <div class="d-flex">
          <img src="${review.userImage}" class="rating-user-img me-3" alt="${review.userName}">
          <div class="flex-grow-1">
            <div class="d-flex justify-content-between align-items-center mb-2">
              <h6 class="mb-0">${review.userName}</h6>
              <div class="d-flex align-items-center">
                <div class="rating-stars me-2">
                  ${starsHtml}
                </div>
                <small class="text-muted">${timeAgo}</small>
              </div>
            </div>
            <p class="mb-1">${review.content}</p>
            <div class="d-flex justify-content-between align-items-center mt-2">
              <div>
                <span class="badge bg-primary me-2">${review.category}</span>
                <span class="badge bg-secondary">${review.product}</span>
                ${review.flagged ? '<span class="badge bg-warning text-dark ms-2">Flagged</span>' : ""}
              </div>
              <div class="crud-actions">
                <button class="btn btn-sm btn-outline-primary" title="Reply">
                  <i class="bi bi-reply"></i>
                </button>
                <button class="btn btn-sm ${review.flagged ? "btn-warning" : "btn-outline-warning"}" title="Flag">
                  <i class="bi bi-flag"></i>
                </button>
                <button class="btn btn-sm btn-outline-danger" title="Delete">
                  <i class="bi bi-trash"></i>
                </button>
              </div>
            </div>
          </div>
        </div>
      `

      // Add animation delay based on index
      reviewItem.style.opacity = "0"
      reviewItem.style.transform = "translateY(20px)"

      setTimeout(() => {
        reviewItem.style.transition = "opacity 0.5s ease, transform 0.5s ease"
        reviewItem.style.opacity = "1"
        reviewItem.style.transform = "translateY(0)"
      }, 100 * index)

      reviewsList.appendChild(reviewItem)
    })
  }

  // Helper function to generate stars HTML
  function generateStarsHtml(rating) {
    let starsHtml = ""
    const fullStars = Math.floor(rating)
    const hasHalfStar = rating % 1 >= 0.5

    // Add full stars
    for (let i = 0; i < fullStars; i++) {
      starsHtml += '<i class="bi bi-star-fill"></i>'
    }

    // Add half star if needed
    if (hasHalfStar) {
      starsHtml += '<i class="bi bi-star-half"></i>'
    }

    // Add empty stars
    const emptyStars = 5 - fullStars - (hasHalfStar ? 1 : 0)
    for (let i = 0; i < emptyStars; i++) {
      starsHtml += '<i class="bi bi-star"></i>'
    }

    return starsHtml
  }

  // Helper function to format date to "time ago"
  function getTimeAgo(date) {
    const seconds = Math.floor((new Date() - date) / 1000)

    let interval = Math.floor(seconds / 31536000)
    if (interval >= 1) {
      return interval + " year" + (interval === 1 ? "" : "s") + " ago"
    }

    interval = Math.floor(seconds / 2592000)
    if (interval >= 1) {
      return interval + " month" + (interval === 1 ? "" : "s") + " ago"
    }

    interval = Math.floor(seconds / 86400)
    if (interval >= 1) {
      return interval + " day" + (interval === 1 ? "" : "s") + " ago"
    }

    interval = Math.floor(seconds / 3600)
    if (interval >= 1) {
      return interval + " hour" + (interval === 1 ? "" : "s") + " ago"
    }

    interval = Math.floor(seconds / 60)
    if (interval >= 1) {
      return interval + " minute" + (interval === 1 ? "" : "s") + " ago"
    }

    return "Just now"
  }
})
