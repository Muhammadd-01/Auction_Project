// Books page JavaScript

// Mock functions for missing dependencies
function loadData() {
  // Replace with actual data loading logic (e.g., from localStorage or an API)
  return {
    books: [
      {
        id: 1,
        title: "The Lord of the Rings",
        subcategory: "Fantasy",
        description: "A classic fantasy novel.",
        startingPrice: 15.0,
        currentBid: 15.0,
        bids: 0,
        status: "active",
        image: "https://via.placeholder.com/200x250?text=LOTR",
      },
      {
        id: 2,
        title: "Pride and Prejudice",
        subcategory: "Romance",
        description: "A beloved romance novel.",
        startingPrice: 12.0,
        currentBid: 12.0,
        bids: 0,
        status: "active",
        image: "https://via.placeholder.com/200x250?text=P%26P",
      },
      {
        id: 3,
        title: "1984",
        subcategory: "Dystopian",
        description: "A chilling dystopian novel.",
        startingPrice: 10.0,
        currentBid: 10.0,
        bids: 0,
        status: "inactive",
        image: "https://via.placeholder.com/200x250?text=1984",
      },
    ],
  }
}

function generateId() {
  // Replace with actual ID generation logic (e.g., using a UUID library)
  return Math.floor(Math.random() * 1000)
}

function saveData() {
  // Replace with actual data saving logic (e.g., to localStorage or an API)
  console.log("Data saved.")
}

const bootstrap = {
  Modal: {
    getInstance: (element) => {
      return {
        hide: () => {
          element.style.display = "none" // Simple mock hide
        },
      }
    },
    getOrCreateInstance: (element) => {
      return {
        show: () => {
          element.style.display = "block" // Simple mock show
        },
        hide: () => {
          element.style.display = "none" // Simple mock hide
        },
      }
    },
  },
}

function showToast(message, type) {
  // Replace with actual toast display logic (e.g., using a library like Toastify)
  console.log(`Toast: ${message} (${type})`)
}

document.addEventListener("DOMContentLoaded", () => {
  // Initialize data
  const data = loadData()

  // Populate books table
  populateBooksTable(data.books)

  // Populate books card view
  populateBooksCardView(data.books)

  // Toggle between table and card view
  const tableViewBtn = document.getElementById("tableViewBtn")
  const cardViewBtn = document.getElementById("cardViewBtn")
  const tableView = document.getElementById("tableView")
  const cardView = document.getElementById("cardView")

  if (tableViewBtn && cardViewBtn) {
    tableViewBtn.addEventListener("click", () => {
      tableViewBtn.classList.add("active")
      cardViewBtn.classList.remove("active")
      tableView.classList.remove("d-none")
      cardView.classList.add("d-none")
    })

    cardViewBtn.addEventListener("click", () => {
      cardViewBtn.classList.add("active")
      tableViewBtn.classList.remove("active")
      cardView.classList.remove("d-none")
      tableView.classList.add("d-none")
    })
  }

  // Search functionality
  const bookSearch = document.getElementById("bookSearch")
  if (bookSearch) {
    bookSearch.addEventListener("input", function () {
      const searchTerm = this.value.toLowerCase()
      filterBooks(searchTerm)
    })
  }

  // Filter by subcategory
  const subcategoryFilter = document.getElementById("subcategoryFilter")
  if (subcategoryFilter) {
    subcategoryFilter.addEventListener("change", () => {
      filterBooks()
    })
  }

  // Filter by status
  const statusFilter = document.getElementById("statusFilter")
  if (statusFilter) {
    statusFilter.addEventListener("change", () => {
      filterBooks()
    })
  }

  // Book form image preview
  const bookImage = document.getElementById("bookImage")
  const bookImagePreview = document.getElementById("bookImagePreview")

  if (bookImage && bookImagePreview) {
    bookImage.addEventListener("change", function () {
      const file = this.files[0]
      if (file) {
        const reader = new FileReader()
        reader.onload = (e) => {
          bookImagePreview.src = e.target.result

          // Add animation
          bookImagePreview.style.transition = "transform 0.5s ease"
          bookImagePreview.style.transform = "scale(1.1)"
          setTimeout(() => {
            bookImagePreview.style.transform = "scale(1)"
          }, 500)
        }
        reader.readAsDataURL(file)
      }
    })
  }

  // Save book button
  const saveBookBtn = document.getElementById("saveBookBtn")
  const bookForm = document.getElementById("bookForm")

  if (saveBookBtn && bookForm) {
    saveBookBtn.addEventListener("click", () => {
      if (!bookForm.checkValidity()) {
        bookForm.classList.add("was-validated")
        return
      }

      // Get form values
      const bookId = document.getElementById("bookId").value
      const title = document.getElementById("bookTitle").value
      const subcategory = document.getElementById("bookSubcategory").value
      const description = document.getElementById("bookDescription").value
      const price = Number.parseFloat(document.getElementById("bookPrice").value)
      const status = document.getElementById("bookStatus").value

      // Create book object
      const book = {
        id: bookId ? Number.parseInt(bookId) : generateId(),
        title,
        subcategory,
        description,
        startingPrice: price,
        currentBid: price,
        bids: 0,
        status,
        image: bookImagePreview.src,
      }

      // Save to data
      const data = loadData()

      if (bookId) {
        // Update existing book
        const index = data.books.findIndex((b) => b.id === Number.parseInt(bookId))
        if (index !== -1) {
          data.books[index] = book
        }
      } else {
        // Add new book
        data.books.push(book)
      }

      // Save data
      saveData()

      // Close modal
      const modal = bootstrap.Modal.getOrCreateInstance(document.getElementById("addItemModal"))
      modal.hide()

      // Refresh table and card view
      populateBooksTable(data.books)
      populateBooksCardView(data.books)

      // Show success message
      showToast(bookId ? "Book updated successfully" : "Book added successfully", "success")

      // Reset form
      bookForm.reset()
      bookForm.classList.remove("was-validated")
      bookImagePreview.src = "https://via.placeholder.com/200x250?text=Book+Cover"
      document.getElementById("bookId").value = ""
      document.getElementById("addItemModalLabel").textContent = "Add New Book"
    })
  }

  // Handle table actions (view, edit, delete)
  const booksTableBody = document.getElementById("booksTableBody")

  if (booksTableBody) {
    booksTableBody.addEventListener("click", (e) => {
      const button = e.target.closest("button")
      if (!button) return

      const bookId = Number.parseInt(button.dataset.id)
      const data = loadData()
      const book = data.books.find((b) => b.id === bookId)

      if (!book) return

      if (button.classList.contains("btn-view")) {
        // View book details
        showToast(`Viewing: ${book.title}`, "info")
        // This would typically open a modal with book details
      } else if (button.classList.contains("btn-edit")) {
        // Edit book
        openEditBookModal(book)
      } else if (button.classList.contains("btn-delete")) {
        // Delete book
        openDeleteConfirmation(bookId)
      }
    })
  }

  // Handle card view actions
  const cardViewContainer = document.getElementById("cardView")

  if (cardViewContainer) {
    cardViewContainer.addEventListener("click", (e) => {
      const button = e.target.closest("button")
      if (!button) return

      const bookId = Number.parseInt(button.dataset.id)
      const data = loadData()
      const book = data.books.find((b) => b.id === bookId)

      if (!book) return

      if (button.classList.contains("btn-view")) {
        // View book details
        showToast(`Viewing: ${book.title}`, "info")
        // This would typically open a modal with book details
      } else if (button.classList.contains("btn-edit")) {
        // Edit book
        openEditBookModal(book)
      } else if (button.classList.contains("btn-delete")) {
        // Delete book
        openDeleteConfirmation(bookId)
      }
    })
  }

  // Confirm delete button
  const confirmDeleteItem = document.getElementById("confirmDeleteItem")

  if (confirmDeleteItem) {
    confirmDeleteItem.addEventListener("click", function () {
      const bookId = Number.parseInt(this.dataset.id)

      // Delete book
      const data = loadData()
      data.books = data.books.filter((book) => book.id !== bookId)
      saveData()

      // Close modal
      const modal = bootstrap.Modal.getInstance(document.getElementById("deleteItemModal"))
      modal.hide()

      // Refresh table and card view
      populateBooksTable(data.books)
      populateBooksCardView(data.books)

      // Show success message
      showToast("Book deleted successfully", "success")
    })
  }
})

// Function to populate books table
function populateBooksTable(books) {
  const booksTableBody = document.getElementById("booksTableBody")
  if (!booksTableBody) return

  booksTableBody.innerHTML = ""

  if (books.length === 0) {
    booksTableBody.innerHTML = `
            <tr>
                <td colspan="8" class="text-center py-4">
                    <div class="d-flex flex-column align-items-center">
                        <i class="bi bi-book text-muted" style="font-size: 3rem;"></i>
                        <p class="mt-3 mb-0">No books found</p>
                    </div>
                </td>
            </tr>
        `
    return
  }

  books.forEach((book, index) => {
    const row = document.createElement("tr")
    row.style.animationDelay = `${index * 0.1}s`

    row.innerHTML = `
            <td>
                <img src="${book.image}" alt="${book.title}" width="60" height="80" class="img-thumbnail">
            </td>
            <td>
                <strong>${book.title}</strong>
            </td>
            <td>
                <span class="badge bg-info">${book.subcategory}</span>
            </td>
            <td>$${book.startingPrice.toFixed(2)}</td>
            <td>$${book.currentBid.toFixed(2)}</td>
            <td>${book.bids}</td>
            <td>
                <span class="badge ${book.status === "active" ? "bg-success" : "bg-secondary"}">${book.status}</span>
            </td>
            <td>
                <div class="crud-actions">
                    <button type="button" class="btn btn-view" data-id="${book.id}" title="View">
                        <i class="bi bi-eye"></i>
                    </button>
                    <button type="button" class="btn btn-edit" data-id="${book.id}" title="Edit">
                        <i class="bi bi-pencil"></i>
                    </button>
                    <button type="button" class="btn btn-delete" data-id="${book.id}" title="Delete">
                        <i class="bi bi-trash"></i>
                    </button>
                </div>
            </td>
        `

    booksTableBody.appendChild(row)
  })
}

// Function to populate books card view
function populateBooksCardView(books) {
  const cardView = document.getElementById("cardView")
  if (!cardView) return

  cardView.innerHTML = ""

  if (books.length === 0) {
    cardView.innerHTML = `
            <div class="col-12 text-center py-5">
                <i class="bi bi-book text-muted" style="font-size: 4rem;"></i>
                <h4 class="mt-3">No books found</h4>
                <p class="text-muted">Try adjusting your filters or add a new book</p>
            </div>
        `
    return
  }

  books.forEach((book, index) => {
    const card = document.createElement("div")
    card.className = "col-md-4 col-lg-3 mb-4"
    card.style.animationDelay = `${index * 0.1}s`

    card.innerHTML = `
            <div class="auction-card h-100">
                <div class="position-relative overflow-hidden">
                    <img src="${book.image}" class="card-img-top" alt="${book.title}">
                    <span class="badge ${book.status === "active" ? "bg-success" : "bg-secondary"}">${book.status}</span>
                </div>
                <div class="card-body">
                    <h5 class="card-title">${book.title}</h5>
                    <p class="card-text text-muted small">${book.description.substring(0, 100)}${book.description.length > 100 ? "..." : ""}</p>
                    <div class="d-flex justify-content-between align-items-center">
                        <span class="badge bg-info">${book.subcategory}</span>
                        <span class="card-price">$${book.currentBid.toFixed(2)}</span>
                    </div>
                </div>
                <div class="card-footer d-flex justify-content-between align-items-center">
                    <small class="text-muted">${book.bids} bids</small>
                    <div class="crud-actions">
                        <button type="button" class="btn btn-view" data-id="${book.id}" title="View">
                            <i class="bi bi-eye"></i>
                        </button>
                        <button type="button" class="btn btn-edit" data-id="${book.id}" title="Edit">
                            <i class="bi bi-pencil"></i>
                        </button>
                        <button type="button" class="btn btn-delete" data-id="${book.id}" title="Delete">
                            <i class="bi bi-trash"></i>
                        </button>
                    </div>
                </div>
                <div class="card-actions">
                    <button class="btn btn-primary" data-id="${book.id}">
                        <i class="bi bi-eye me-1"></i> Quick View
                    </button>
                    <button class="btn btn-outline-primary" data-id="${book.id}">
                        <i class="bi bi-pencil me-1"></i> Edit
                    </button>
                </div>
            </div>
        `

    cardView.appendChild(card)
  })
}

// Function to filter books
function filterBooks(searchTerm = "") {
  const subcategoryFilter = document.getElementById("subcategoryFilter").value
  const statusFilter = document.getElementById("statusFilter").value
  const searchInput = document.getElementById("bookSearch").value.toLowerCase()

  // Combine search terms
  searchTerm = searchTerm || searchInput

  const data = loadData()
  let filteredBooks = data.books

  // Apply subcategory filter
  if (subcategoryFilter !== "all") {
    filteredBooks = filteredBooks.filter((book) => book.subcategory === subcategoryFilter)
  }

  // Apply status filter
  if (statusFilter !== "all") {
    filteredBooks = filteredBooks.filter((book) => book.status === statusFilter)
  }

  // Apply search filter
  if (searchTerm) {
    filteredBooks = filteredBooks.filter(
      (book) => book.title.toLowerCase().includes(searchTerm) || book.description.toLowerCase().includes(searchTerm),
    )
  }

  // Update views
  populateBooksTable(filteredBooks)
  populateBooksCardView(filteredBooks)
}

// Function to open edit book modal
function openEditBookModal(book) {
  // Set modal title
  document.getElementById("addItemModalLabel").textContent = "Edit Book"

  // Fill form fields
  document.getElementById("bookId").value = book.id
  document.getElementById("bookTitle").value = book.title
  document.getElementById("bookSubcategory").value = book.subcategory
  document.getElementById("bookDescription").value = book.description
  document.getElementById("bookPrice").value = book.startingPrice.toFixed(2)
  document.getElementById("bookStatus").value = book.status
  document.getElementById("bookImagePreview").src = book.image

  // Show modal
  const modal = bootstrap.Modal.getOrCreateInstance(document.getElementById("addItemModal"))
  modal.show()
}

// Function to open delete confirmation
function openDeleteConfirmation(bookId) {
  // Set book ID to delete button
  document.getElementById("confirmDeleteItem").dataset.id = bookId

  // Show modal
  const modal = bootstrap.Modal.getOrCreateInstance(document.getElementById("deleteItemModal"))
  modal.show()
}
