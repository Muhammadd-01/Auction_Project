// Category Management JavaScript

// Sample data for demonstration
let categories = [
  { id: 1, name: "Books", parent: null, icon: "fa-book", active: true, image: "/placeholder.svg?height=50&width=50" },
  {
    id: 2,
    name: "Electronics",
    parent: null,
    icon: "fa-laptop",
    active: true,
    image: "/placeholder.svg?height=50&width=50",
  },
  {
    id: 3,
    name: "Furniture",
    parent: null,
    icon: "fa-couch",
    active: true,
    image: "/placeholder.svg?height=50&width=50",
  },
  {
    id: 4,
    name: "Fiction",
    parent: 1,
    icon: "fa-book-open",
    active: true,
    image: "/placeholder.svg?height=50&width=50",
  },
  {
    id: 5,
    name: "Non-Fiction",
    parent: 1,
    icon: "fa-book-reader",
    active: true,
    image: "/placeholder.svg?height=50&width=50",
  },
  {
    id: 6,
    name: "Smartphones",
    parent: 2,
    icon: "fa-mobile-alt",
    active: true,
    image: "/placeholder.svg?height=50&width=50",
  },
  {
    id: 7,
    name: "Laptops",
    parent: 2,
    icon: "fa-laptop-code",
    active: true,
    image: "/placeholder.svg?height=50&width=50",
  },
  { id: 8, name: "Chairs", parent: 3, icon: "fa-chair", active: false, image: "/placeholder.svg?height=50&width=50" },
  { id: 9, name: "Tables", parent: 3, icon: "fa-table", active: true, image: "/placeholder.svg?height=50&width=50" },
]

// DOM Elements
const categoryForm = document.getElementById("categoryForm")
const categoryIdInput = document.getElementById("categoryId")
const categoryNameInput = document.getElementById("categoryName")
const parentCategorySelect = document.getElementById("parentCategory")
const categoryIconInput = document.getElementById("categoryIcon")
const categoryImageInput = document.getElementById("categoryImage")
const isActiveCheckbox = document.getElementById("isActive")
const submitBtn = document.getElementById("submitBtn")
const cancelBtn = document.getElementById("cancelBtn")
const formTitle = document.getElementById("form-title")
const categoriesTableBody = document.getElementById("categoriesTableBody")
const categoryTree = document.getElementById("categoryTree")
const noCategoriesMessage = document.getElementById("noCategoriesMessage")
const categorySearchInput = document.getElementById("categorySearchInput")

// Initialize Bootstrap Modal (if not already initialized)
const deleteModalElement = document.getElementById("deleteModal")
let deleteModal

if (deleteModalElement) {
  deleteModal = new bootstrap.Modal(deleteModalElement)
} else {
  console.error("Delete modal element not found in the DOM.")
}

const deleteCategoryName = document.getElementById("deleteCategoryName")
const confirmDeleteBtn = document.getElementById("confirmDeleteBtn")

// Initialize the page
document.addEventListener("DOMContentLoaded", () => {
  loadCategories()
  loadCategoryTree()
  loadParentCategoryOptions()

  // Event listeners
  categoryForm.addEventListener("submit", handleFormSubmit)
  cancelBtn.addEventListener("click", resetForm)
  categorySearchInput.addEventListener("input", filterCategories)
  confirmDeleteBtn.addEventListener("click", confirmDelete)
})

// Load categories into the table
function loadCategories() {
  if (categories.length === 0) {
    categoriesTableBody.innerHTML = ""
    noCategoriesMessage.classList.remove("d-none")
    return
  }

  noCategoriesMessage.classList.add("d-none")
  categoriesTableBody.innerHTML = ""

  categories.forEach((category) => {
    const parentName = category.parent ? categories.find((c) => c.id === category.parent)?.name : "-"

    const row = document.createElement("tr")
    row.innerHTML = `
            <td>
                <div class="d-flex align-items-center">
                    <div class="category-icon me-2">
                        <i class="fas ${category.icon}"></i>
                    </div>
                    <div>
                        <strong>${category.name}</strong>
                    </div>
                </div>
            </td>
            <td>${parentName}</td>
            <td><i class="fas ${category.icon}"></i> ${category.icon}</td>
            <td>
                <span class="status-badge ${category.active ? "status-active" : "status-inactive"}">
                    ${category.active ? "Active" : "Inactive"}
                </span>
            </td>
            <td>
                <div class="action-buttons">
                    <button class="btn btn-sm btn-outline-primary edit-btn" data-id="${category.id}">
                        <i class="fas fa-edit"></i>
                    </button>
                    <button class="btn btn-sm btn-outline-danger delete-btn" data-id="${category.id}" data-name="${category.name}">
                        <i class="fas fa-trash-alt"></i>
                    </button>
                </div>
            </td>
        `

    categoriesTableBody.appendChild(row)
  })

  // Add event listeners to edit and delete buttons
  document.querySelectorAll(".edit-btn").forEach((btn) => {
    btn.addEventListener("click", () => editCategory(Number.parseInt(btn.dataset.id)))
  })

  document.querySelectorAll(".delete-btn").forEach((btn) => {
    btn.addEventListener("click", () => showDeleteConfirmation(Number.parseInt(btn.dataset.id), btn.dataset.name))
  })
}

// Load category tree view
function loadCategoryTree() {
  categoryTree.innerHTML = ""

  // Get top-level categories
  const topLevelCategories = categories.filter((c) => c.parent === null)

  if (topLevelCategories.length === 0) {
    categoryTree.innerHTML = '<div class="text-center py-3">No categories found</div>'
    return
  }

  topLevelCategories.forEach((parent) => {
    const children = categories.filter((c) => c.parent === parent.id)

    const parentElement = document.createElement("div")
    parentElement.className = "category-tree-item"

    const parentHeader = document.createElement("div")
    parentHeader.className = "category-tree-parent"
    parentHeader.innerHTML = `
            <i class="fas ${parent.icon}"></i>
            <span>${parent.name}</span>
            ${!parent.active ? '<span class="ms-2 badge bg-danger">Inactive</span>' : ""}
        `

    parentElement.appendChild(parentHeader)

    if (children.length > 0) {
      const childrenContainer = document.createElement("div")
      childrenContainer.className = "category-tree-children"

      children.forEach((child) => {
        const childElement = document.createElement("div")
        childElement.className = "category-tree-child"
        childElement.innerHTML = `
                    <i class="fas ${child.icon}"></i>
                    <span>${child.name}</span>
                    ${!child.active ? '<span class="ms-2 badge bg-danger">Inactive</span>' : ""}
                `

        childrenContainer.appendChild(childElement)
      })

      parentElement.appendChild(childrenContainer)
    }

    categoryTree.appendChild(parentElement)
  })
}

// Load parent category options in the select dropdown
function loadParentCategoryOptions() {
  // Clear existing options except the first one
  while (parentCategorySelect.options.length > 1) {
    parentCategorySelect.remove(1)
  }

  // Add top-level categories as options
  categories
    .filter((c) => c.parent === null)
    .forEach((category) => {
      const option = document.createElement("option")
      option.value = category.id
      option.textContent = category.name
      parentCategorySelect.appendChild(option)
    })
}

// Handle form submission (add or edit)
function handleFormSubmit(e) {
  e.preventDefault()

  const id = categoryIdInput.value ? Number.parseInt(categoryIdInput.value) : generateId()
  const name = categoryNameInput.value.trim()
  const parent = parentCategorySelect.value ? Number.parseInt(parentCategorySelect.value) : null
  const icon = categoryIconInput.value.trim() || "fa-tag"
  const active = isActiveCheckbox.checked

  // Validate that we're not creating a circular reference
  if (parent && id === parent) {
    alert("A category cannot be its own parent.")
    return
  }

  // Check if we're editing or adding
  const isEditing = categoryIdInput.value !== ""

  if (isEditing) {
    // Update existing category
    const index = categories.findIndex((c) => c.id === id)
    if (index !== -1) {
      categories[index] = {
        ...categories[index],
        name,
        parent,
        icon,
        active,
      }
    }
  } else {
    // Add new category
    const newCategory = {
      id,
      name,
      parent,
      icon,
      active,
      image: "/placeholder.svg?height=50&width=50", // Default placeholder image
    }

    categories.push(newCategory)
  }

  // Reset form and reload data
  resetForm()
  loadCategories()
  loadCategoryTree()
  loadParentCategoryOptions()
}

// Edit category
function editCategory(id) {
  const category = categories.find((c) => c.id === id)
  if (!category) return

  // Populate form
  categoryIdInput.value = category.id
  categoryNameInput.value = category.name
  parentCategorySelect.value = category.parent || ""
  categoryIconInput.value = category.icon
  isActiveCheckbox.checked = category.active

  // Update UI
  formTitle.textContent = "Edit Category"
  submitBtn.textContent = "Update Category"
  cancelBtn.classList.remove("d-none")

  // Scroll to form
  document.querySelector(".category-form-card").scrollIntoView({ behavior: "smooth" })
}

// Show delete confirmation modal
function showDeleteConfirmation(id, name) {
  deleteCategoryName.textContent = name
  confirmDeleteBtn.dataset.id = id
  deleteModal.show()
}

// Confirm delete
function confirmDelete() {
  const id = Number.parseInt(confirmDeleteBtn.dataset.id)

  // Check if category has children
  const hasChildren = categories.some((c) => c.parent === id)

  if (hasChildren) {
    // Remove children first
    categories = categories.filter((c) => c.parent !== id)
  }

  // Remove the category
  categories = categories.filter((c) => c.id !== id)

  // Hide modal and reload data
  deleteModal.hide()
  loadCategories()
  loadCategoryTree()
  loadParentCategoryOptions()
}

// Reset form to add mode
function resetForm() {
  categoryForm.reset()
  categoryIdInput.value = ""
  formTitle.textContent = "Add New Category"
  submitBtn.textContent = "Add Category"
  cancelBtn.classList.add("d-none")
}

// Filter categories based on search input
function filterCategories() {
  const searchTerm = categorySearchInput.value.toLowerCase()

  document.querySelectorAll("#categoriesTableBody tr").forEach((row) => {
    const categoryName = row.querySelector("td:first-child strong").textContent.toLowerCase()
    if (categoryName.includes(searchTerm)) {
      row.style.display = ""
    } else {
      row.style.display = "none"
    }
  })
}

// Generate a unique ID for new categories
function generateId() {
  return Math.max(0, ...categories.map((c) => c.id)) + 1
}

// Handle image upload preview (not implemented in this demo)
categoryImageInput.addEventListener("change", function () {
  // In a real application, you would handle file upload and preview here
  console.log("Image selected:", this.files[0]?.name || "None")
})
